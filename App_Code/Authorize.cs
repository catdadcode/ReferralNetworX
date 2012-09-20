using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArbApiSample;
using System.Xml;
using System.Net;
using System.Text;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Authorize
/// </summary>
public static class Authorize
{
    public static string CreateSubscription(string firstName, string lastName, string email, 
        string cardNumber, string expiration, decimal price, DateTime startDate)
    {
        ARBCreateSubscriptionRequest createSubscriptionRequest = new ARBCreateSubscriptionRequest();
        ARBSubscriptionType subscription = new ARBSubscriptionType();
        creditCardType creditCard = new creditCardType();

        subscription.name = "Referral NetworX";

        creditCard.cardNumber = cardNumber;
        creditCard.expirationDate = expiration;
        subscription.payment = new paymentType();
        subscription.payment.Item = creditCard;

        subscription.billTo = new nameAndAddressType
        {
            firstName = firstName,
            lastName = lastName
        };

        subscription.paymentSchedule = new paymentScheduleType
        {
            startDate = startDate,
            startDateSpecified = true,
            totalOccurrences = 9999,
            totalOccurrencesSpecified = true,
            trialOccurrencesSpecified = false,
            interval = new paymentScheduleTypeInterval
            {
                length = 1,
                unit = ARBSubscriptionUnitEnum.months
            }
        };

        subscription.trialAmountSpecified = false;
        subscription.amount = price;
        subscription.amountSpecified = true;

        subscription.customer = new customerType
        {
            email = email
        };

        ANetApiRequest aNetRequest = (ANetApiRequest)createSubscriptionRequest;
        aNetRequest.merchantAuthentication = new merchantAuthenticationType
        {
            name = "8n3jE77yAPK",
            transactionKey = "7C5v485g9vKJZ9mH"
        };

        createSubscriptionRequest.subscription = subscription;

        //////////////////////

        XmlSerializer serializer;
        XmlDocument xmldoc;

        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://api.authorize.net/xml/v1/request.api");
        webRequest.Method = "POST";
        webRequest.ContentType = "text/xml";
        webRequest.KeepAlive = true;

        serializer = new XmlSerializer(createSubscriptionRequest.GetType());
        XmlWriter xmlwriter = new XmlTextWriter(webRequest.GetRequestStream(), Encoding.UTF8);
        serializer.Serialize(xmlwriter, createSubscriptionRequest);
        xmlwriter.Close();

        WebResponse webResponse = webRequest.GetResponse();

        xmldoc = new XmlDocument();
        xmldoc.Load(XmlReader.Create(webResponse.GetResponseStream()));

        object apiResponse = null;
        switch (xmldoc.DocumentElement.Name)
        {
            case "ARBCreateSubscriptionResponse":
                serializer = new XmlSerializer(typeof(ARBCreateSubscriptionResponse));
                apiResponse = (ARBCreateSubscriptionResponse)serializer.Deserialize(new StringReader(xmldoc.DocumentElement.OuterXml));
                break;

            case "ARBUpdateSubscriptionResponse":
                serializer = new XmlSerializer(typeof(ARBUpdateSubscriptionResponse));
                apiResponse = (ARBUpdateSubscriptionResponse)serializer.Deserialize(new StringReader(xmldoc.DocumentElement.OuterXml));
                break;

            case "ARBCancelSubscriptionResponse":
                serializer = new XmlSerializer(typeof(ARBCancelSubscriptionResponse));
                apiResponse = (ARBCancelSubscriptionResponse)serializer.Deserialize(new StringReader(xmldoc.DocumentElement.OuterXml));
                break;

            case "ARBGetSubscriptionStatusResponse":
                serializer = new XmlSerializer(typeof(ARBGetSubscriptionStatusResponse));
                apiResponse = (ARBGetSubscriptionStatusResponse)serializer.Deserialize(new StringReader(xmldoc.DocumentElement.OuterXml));
                break;

            case "ErrorResponse":
                serializer = new XmlSerializer(typeof(ANetApiResponse));
                apiResponse = (ANetApiResponse)serializer.Deserialize(new StringReader(xmldoc.DocumentElement.OuterXml));
                break;
        }

        ANetApiResponse baseResponse = (ANetApiResponse)apiResponse;
        //display.InnerHtml = baseResponse.messages.resultCode.ToString() + "<br />";
        string subscriptionId = null;
        if (baseResponse.messages.resultCode == messageTypeEnum.Ok)
        {
            if (apiResponse.GetType() == typeof(ARBCreateSubscriptionResponse))
            {
                ARBCreateSubscriptionResponse createSubscriptionResponse = (ARBCreateSubscriptionResponse)apiResponse;
                subscriptionId = createSubscriptionResponse.subscriptionId;
            }
        }
        else
        {
            foreach (messagesTypeMessage message in baseResponse.messages.message)
            {
                subscriptionId += message.code + ": " + message.text + "<br />";
            }
        }
        return subscriptionId;
    }
}