using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
    SqlConnection sConnection = new SqlConnection("dummy");

    public DataLayer()
    {
    }

    public void CloseConn()
    {
        try { sConnection.Close(); }
        catch { }
    }

    #region -= APPRECIATION JOURNAL TABLE =-

    public int AddAJEntry(string sAuthor, DateTime dtDate, string sBody)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxAppreciationJournal VALUES (@Author,@Date,@Body)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Author", sAuthor));
        scomm.Parameters.Add(new SqlParameter("Date", dtDate));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateAJEntry(int iEntryID, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxAppreciationJournal SET Body=@Body WHERE EntryID=@EntryID", sConnection);
        scomm.Parameters.Add(new SqlParameter("EntryID", iEntryID));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFifteenAJEntriesBy_Page(int iPageNumber, string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxAppreciationJournal WHERE EntryID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) EntryID FROM rnxAppreciationJournal WHERE Author=@Email ORDER BY Date ASC) AND Author=@Email ORDER BY Date ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetAJEntryCount(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Entry Count' FROM rnxAppreciationJournal WHERE Author=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetAJEntryBy_EntryID(int iEntryID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxAppreciationJournal WHERE EntryID=@EntryID", sConnection);
        sc.Parameters.Add(new SqlParameter("EntryID", iEntryID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetAJEntryBy_UserAndDate(string sEmail, DateTime dtDate)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxAppreciationJournal WHERE Author=@Author AND Date=@Date", sConnection);
        sc.Parameters.Add(new SqlParameter("Author", sEmail));
        sc.Parameters.Add(new SqlParameter("Date", dtDate));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= TOMORROW PLANNER TABLE =-

    public int AddTPEntry(string sAuthor, DateTime dtDate, string sBody)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxTomorrowPlanner VALUES (@Author,@Date,@Body)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Author", sAuthor));
        scomm.Parameters.Add(new SqlParameter("Date", dtDate));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateTPEntry(int iEntryID, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxTomorrowPlanner SET Body=@Body WHERE EntryID=@EntryID", sConnection);
        scomm.Parameters.Add(new SqlParameter("EntryID", iEntryID));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFifteenTPEntriesBy_Page(int iPageNumber, string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxTomorrowPlanner WHERE EntryID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) EntryID FROM rnxTomorrowPlanner WHERE Author=@Author ORDER BY Date ASC) AND Author=@Author ORDER BY Date ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("Author", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetTPEntryCount(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Entry Count' FROM rnxTomorrowPlanner WHERE Author=@Author", sConnection);
        sc.Parameters.Add(new SqlParameter("Author", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetTPEntryBy_EntryID(int iEntryID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxTomorrowPlanner WHERE EntryID=@EntryID", sConnection);
        sc.Parameters.Add(new SqlParameter("EntryID", iEntryID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetTPEntryBy_UserAndDate(string sEmail, DateTime dtDate)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxTomorrowPlanner WHERE Author=@Email AND Date=@Date", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        sc.Parameters.Add(new SqlParameter("Date", dtDate));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= SUCCESS METER TABLE =-

    public int AddSMEntry(string sAuthor, DateTime dtDate, string sBody, int iRating)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxSuccessTracker VALUES (@Author,@Date,@Body,@Rating)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Author", sAuthor));
        scomm.Parameters.Add(new SqlParameter("Date", dtDate));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("Rating", iRating));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateSMEntry(int iEntryID, string sBody, int iRating)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxSuccessTracker SET Body=@Body, Rating=@Rating WHERE EntryID=@EntryID", sConnection);
        scomm.Parameters.Add(new SqlParameter("EntryID", iEntryID));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("Rating", iRating));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFifteenSMEntriesBy_Page(int iPageNumber, string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxSuccessTracker WHERE EntryID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) EntryID FROM rnxSuccessTracker WHERE Author=@Author ORDER BY Date ASC) AND Author=@Author ORDER BY Date ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("Author", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetSMEntryCount(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Entry Count' FROM rnxSuccessTracker WHERE Author=@Author", sConnection);
        sc.Parameters.Add(new SqlParameter("Author", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetSMEntryBy_EntryID(int iEntryID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxSuccessTracker WHERE EntryID=@EntryID", sConnection);
        sc.Parameters.Add(new SqlParameter("EntryID", iEntryID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetSMEntryBy_UserAndDate(string sEmail, DateTime dtDate)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxSuccessTracker WHERE Author=@Author AND Date=@Date", sConnection);
        sc.Parameters.Add(new SqlParameter("Author", sEmail));
        sc.Parameters.Add(new SqlParameter("Date", dtDate));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= MEMBER ADS TABLE =-

    public DataTable GetRandomAd()
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 1 * FROM rnxMemberAds ORDER BY NEWID()", sConnection);
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= COMMENTS TABLE =-

    public int AddComment(string sAuthorEmail, DateTime dtDate, string sBody, string sType, bool bThumbsUp, int iBlogID, string sMemberID)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxComments VALUES (@AuthorEmail,@Date,@Body,@Type,@ThumbsUp,@BlogID,@MemberID)", sConnection);
        scomm.Parameters.Add(new SqlParameter("AuthorEmail", sAuthorEmail));
        scomm.Parameters.Add(new SqlParameter("Date", dtDate));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("Type", sType));
        scomm.Parameters.Add(new SqlParameter("ThumbsUp", bThumbsUp));
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        scomm.Parameters.Add(new SqlParameter("MemberID", sMemberID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteComment(int iCommentID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxComments WHERE CommentID=@CommentID", sConnection);
        scomm.Parameters.Add(new SqlParameter("CommentID", iCommentID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFifteenBlogCommentsBy_Page(int iPageNumber, int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxComments WHERE CommentID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) CommentID FROM rnxComments WHERE BlogID=@BlogID ORDER BY Date ASC) AND BlogID=@BlogID ORDER BY Date ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFifteenMemberCommentsBy_Page(int iPageNumber, string sMemberID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxComments WHERE CommentID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) CommentID FROM rnxComments WHERE MemberID=@MemberID ORDER BY Date DESC) AND MemberID=@MemberID ORDER BY Date DESC", sConnection);
        sc.Parameters.Add(new SqlParameter("MemberID", sMemberID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetBlogCommentCount(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Comment Count' FROM rnxComments WHERE BlogID=@BlogID", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public int GetBlogThumbsUpCount(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Thumbs Up Count' FROM rnxComments WHERE BlogID=@BlogID AND ThumbsUp='True'", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public bool GaveMemberThumbsUpAlready(string sMemberID, string sAuthor)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Thumbs Up Count' FROM rnxComments WHERE MemberID=@MemberID AND ThumbsUp='True' AND Author=@Author", sConnection);
        sc.Parameters.Add(new SqlParameter("MemberID", sMemberID));
        sc.Parameters.Add(new SqlParameter("Author", sAuthor));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetMemberCommentCount(string sMemberID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Comment Count' FROM rnxComments WHERE MemberID=@MemberID", sConnection);
        sc.Parameters.Add(new SqlParameter("MemberID", sMemberID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public int GetMemberThumbsUpCount(string sMemberID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Thumbs Up Count' FROM rnxComments WHERE MemberID=@MemberID AND ThumbsUp='True'", sConnection);
        sc.Parameters.Add(new SqlParameter("MemberID", sMemberID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public bool GaveBlogThumbsUpAlready(int iBlogID, string sAuthor)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Thumbs Up Count' FROM rnxComments WHERE BlogID=@BlogID AND ThumbsUp='True' AND Author=@Author", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        sc.Parameters.Add(new SqlParameter("Author", sAuthor));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataTable GetCommentBy_CommentID(int iCommentID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxComments WHERE CommentID=@CommentID", sConnection);
        sc.Parameters.Add(new SqlParameter("CommentID", iCommentID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= DAILYMOTIVATOR TABLE =-

    public int AddDailyMotivator(DateTime dtPostedDate, string sTitle, string sYouTubeLink, string sBody)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxDailyMotivator VALUES (@PostedDate,'false',@Title,@Body,@YouTubeLink)", sConnection);
        scomm.Parameters.Add(new SqlParameter("PostedDate", dtPostedDate));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("YouTubeLink", sYouTubeLink));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateDailyMotivator(int iMotivatorID, string sTitle, string sYouTubeLink, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxDailyMotivator SET Title=@Title, YouTubeLink=@YouTubeLink, Body=@Body WHERE MotivatorID=@MotivatorID", sConnection);
        scomm.Parameters.Add(new SqlParameter("MotivatorID", iMotivatorID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("YouTubeLink", sYouTubeLink));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int MarkDailyMotivatorSent(int iMotivatorID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxDailyMotivator SET Sent='true' WHERE MotivatorID=@MotivatorID", sConnection);
        scomm.Parameters.Add(new SqlParameter("MotivatorID", iMotivatorID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteDailyMotivator(int iMotivatorID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxDailyMotivator WHERE MotivatorID=@MotivatorID", sConnection);
        scomm.Parameters.Add(new SqlParameter("MotivatorID", iMotivatorID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetDailyMotivatorTitlesAndIDs()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Title,MotivatorID FROM rnxDailyMotivator WHERE Sent='false' ORDER BY DateEntered DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetLastSentDailyMotivator()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM rnxDailyMotivator WHERE Sent='True' ORDER BY DateEntered DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetLastUnSentDailyMotivator()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM rnxDailyMotivator WHERE Sent='False' ORDER BY DateEntered ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetDailyMotivatorBy_MotivatorID(int iMotivatorID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxDailyMotivator WHERE MotivatorID=@MotivatorID", sConnection);
        sc.Parameters.Add(new SqlParameter("MotivatorID", iMotivatorID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetTenDailyMotivatorsBy_Page(int iPageNumber)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 10 * FROM rnxDailyMotivator WHERE MotivatorID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*10) MotivatorID FROM rnxDailyMotivator WHERE Sent='True' ORDER BY DateEntered DESC) AND Sent='True' ORDER BY DateEntered DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public int GetDailyMotivatorCount()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)AS 'Daily Motivator Count' FROM rnxDailyMotivator WHERE Sent='True'", sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    #endregion

    #region -= ARTICLES TABLE =-

    public int AddArticle(DateTime dtPostedDate, string sTitle, string sBody, string sAuthor, string sCategory)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxArticles VALUES (@PostedDate,@Title,@Body,@Author,@Category)", sConnection);
        scomm.Parameters.Add(new SqlParameter("PostedDate", dtPostedDate));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("Author", sAuthor));
        scomm.Parameters.Add(new SqlParameter("Category", sCategory));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateArticle(int iArticleID, string sTitle, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxArticles SET Title=@Title, Body=@Body WHERE ArticleID=@ArticleID", sConnection);
        scomm.Parameters.Add(new SqlParameter("ArticleID", iArticleID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteArticle(int iArticleID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxArticles WHERE ArticleID=@ArticleID", sConnection);
        scomm.Parameters.Add(new SqlParameter("ArticleID", iArticleID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetArticleTitlesAndIDsBy_Category(string sCategory)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Title,ArticleID FROM rnxArticles WHERE Category=@Category", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetArticleTitlesAndIDsBy_CategoryAndAuthor(string sCategory, string sAuthor)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Title,ArticleID FROM rnxArticles WHERE Category=@Category AND Author=@Author", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        sc.Parameters.Add(new SqlParameter("Author", sAuthor));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFifteenArticlesBy_Category(string sCategory, int iPageNumber)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxArticles WHERE ArticleID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) ArticleID FROM rnxArticles WHERE Category=@Category ORDER BY Date DESC) AND Category=@Category ORDER BY Date DESC", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetRandomArticleBy_Category(string sCategory)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 1 * FROM rnxArticles WHERE Category=@Category ORDER BY NEWID()", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFiveLatestArticles()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 5 * FROM rnxArticles ORDER BY Date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetArticleBy_ArticleID(int iArticleID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxArticles WHERE ArticleID=@ArticleID", sConnection);
        sc.Parameters.Add(new SqlParameter("ArticleID", iArticleID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetArticleCountBy_Category(string sCategory)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Article Count' FROM rnxArticles WHERE Category=@Category", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    #endregion

    #region -= FAQ TABLE =-

    public int AddFAQ(string sQuestion, string sAnswer)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxFAQ VALUES (@Question,@Answer)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Question", sQuestion));
        scomm.Parameters.Add(new SqlParameter("Answer", sAnswer));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateFAQ(int iFAQID, string sQuestion, string sAnswer)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxFAQ SET Question=@Question, Answer=@Answer WHERE FAQID=@FAQID", sConnection);
        scomm.Parameters.Add(new SqlParameter("FAQID", iFAQID));
        scomm.Parameters.Add(new SqlParameter("Question", sQuestion));
        scomm.Parameters.Add(new SqlParameter("Answer", sAnswer));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteFAQ(int iFAQID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxFAQ WHERE FAQID=@FAQID", sConnection);
        scomm.Parameters.Add(new SqlParameter("FAQID", iFAQID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFAQQuestionsAndIDs()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Question,FAQID FROM rnxFAQ", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetAllFAQs()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM rnxFAQ", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFAQBy_FAQID(int iFAQID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxFAQ WHERE FAQID=@FAQID", sConnection);
        sc.Parameters.Add(new SqlParameter("FAQID", iFAQID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= ARTICLE CATEGORIES TABLE =-

    public int AddCategory(string sCategory, string sParentCategory)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxArticleCategories VALUES (@Category,@ParentCategory)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Category", sCategory));
        scomm.Parameters.Add(new SqlParameter("ParentCategory", sParentCategory));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateCategory(string sCategory, string sNewCategory, string sParentCategory)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxArticleCategories SET CategoryName=@NewCategory, ParentCategory=@ParentCategory WHERE CategoryName=@Category", sConnection);
        scomm.Parameters.Add(new SqlParameter("NewCategory", sNewCategory));
        scomm.Parameters.Add(new SqlParameter("ParentCategory", sParentCategory));
        scomm.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlCommand scomm2 = new SqlCommand("UPDATE rnxArticleCategories SET ParentCategory=@NewCategory WHERE ParentCategory=@Category", sConnection);
        scomm2.Parameters.Add(new SqlParameter("NewCategory", sNewCategory));
        scomm2.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlCommand scomm3 = new SqlCommand("UPDATE rnxArticles SET Category=@NewCategory WHERE Category=@Category", sConnection);
        scomm3.Parameters.Add(new SqlParameter("NewCategory", sNewCategory));
        scomm3.Parameters.Add(new SqlParameter("Category", sCategory));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        iRowsAffected += scomm2.ExecuteNonQuery();
        iRowsAffected += scomm3.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteCategory(string sCategory)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxArticleCategories WHERE CategoryName=@Category", sConnection);
        scomm.Parameters.Add(new SqlParameter("Category", sCategory));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public string GetParentCategory(string sCategory)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT ParentCategory FROM rnxArticleCategories WHERE CategoryName=@Category", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public DataTable GetCategories()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM rnxArticleCategories ORDER BY CategoryName ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetCategoriesBy_ParentCategory(string sParentCategory)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT CategoryName FROM rnxArticleCategories WHERE ParentCategory=@ParentCategory ORDER BY CategoryName ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("ParentCategory", sParentCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetParentCategories()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM rnxArticleCategories WHERE ParentCategory='None' ORDER BY CategoryName DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= GROUP TABLE =-

    public int AddGroup(string sGroup, string sDescription, string sState)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxGroups VALUES (@Group,@Description,@State)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Group", sGroup));
        scomm.Parameters.Add(new SqlParameter("Description", sDescription));
        scomm.Parameters.Add(new SqlParameter("State", sState));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateGroup(string sGroup, string sGroup2, string sDescription, string sState)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxGroups SET Name=@Group2, Description=@Description, State=@State WHERE Name=@Group", sConnection);
        scomm.Parameters.Add(new SqlParameter("Group", sGroup));
        scomm.Parameters.Add(new SqlParameter("Group2", sGroup2));
        scomm.Parameters.Add(new SqlParameter("Description", sDescription));
        scomm.Parameters.Add(new SqlParameter("State", sState));
        try { sConnection.Open(); }
        catch { }
        if (sGroup != sGroup2)
        {
            SqlCommand scomm2 = new SqlCommand("UPDATE rnxMembers SET [Group]=@Group2 WHERE [Group]=@Group", sConnection);
            scomm2.Parameters.Add(new SqlParameter("Group", sGroup));
            scomm2.Parameters.Add(new SqlParameter("Group2", sGroup2));
            scomm2.ExecuteNonQuery();
        }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteGroup(string sGroup)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxGroups WHERE Name=@Group", sConnection);
        scomm.Parameters.Add(new SqlParameter("Group", sGroup));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetGroups()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM rnxGroups ORDER BY Name ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetGroupsBy_State(string sState)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxGroups WHERE State=@State ORDER BY Name ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("State", sState));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetGroupStates()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT State FROM rnxGroups", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetGroupBy_GroupName(string sGroup)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxGroups WHERE Name=@Group ORDER BY Name ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("Group", sGroup));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= FORUM POSTS TABLE =-

    public int AddForumPost(int iTopicID, string sAuthor, DateTime dtPostedDate, string sBody)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxForumPosts VALUES (@TopicID,@Author,@PostedDate,@Body)", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        scomm.Parameters.Add(new SqlParameter("Author", sAuthor));
        scomm.Parameters.Add(new SqlParameter("PostedDate", dtPostedDate));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        SqlCommand scomm2 = new SqlCommand("UPDATE rnxForumTopics SET LastReplyDate=@PostedDate WHERE TopicID=@TopicID", sConnection);
        scomm2.Parameters.Add(new SqlParameter("PostedDate", dtPostedDate));
        scomm2.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateForumPost(int iPostID, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumPosts SET Body=@Body WHERE PostID=@PostID", sConnection);
        scomm.Parameters.Add(new SqlParameter("PostID", iPostID));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteForumPost(int iPostID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxForumPosts WHERE PostID=@PostID", sConnection);
        scomm.Parameters.Add(new SqlParameter("PostID", iPostID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFifteenPostsBy_Page(int iPageNumber, int iTopicID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxForumPosts WHERE PostID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) PostID FROM rnxForumPosts WHERE TopicID=@TopicID ORDER BY Date ASC) AND TopicID=@TopicID ORDER BY Date ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetForumPostBy_PostID(int iPostID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxForumPosts WHERE PostID=@PostID", sConnection);
        sc.Parameters.Add(new SqlParameter("PostID", iPostID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= FORUM TOPICS TABLE =-

    public int AddForumTopic(int iBoardID, string sAuthor, string sTitle, string sBody, DateTime dtPostedDate, bool bSticky, bool bLocked)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxForumTopics VALUES (@BoardID,@Author,@PostedDate,@Title,@Body,@Sticky,@Locked,@PostedDate)", sConnection);
        scomm.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        scomm.Parameters.Add(new SqlParameter("Author", sAuthor));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("PostedDate", dtPostedDate));
        scomm.Parameters.Add(new SqlParameter("Sticky", bSticky));
        scomm.Parameters.Add(new SqlParameter("Locked", bLocked));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateForumTopic(int iTopicID, string sTitle, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumTopics SET Title=@Title, Body=@Body WHERE TopicID=@TopicID", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int LockForumTopic(int iTopicID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumTopics SET Locked='true' WHERE TopicID=@TopicID", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int StickyForumTopic(int iTopicID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumTopics SET Sticky='true' WHERE TopicID=@TopicID", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UnlockForumTopic(int iTopicID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumTopics SET Locked='false' WHERE TopicID=@TopicID", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UnstickyForumTopic(int iTopicID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumTopics SET Sticky='false' WHERE TopicID=@TopicID", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteForumTopic(int iTopicID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxForumTopics WHERE TopicID=@TopicID", sConnection);
        scomm.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        SqlCommand scomm2 = new SqlCommand("DELETE FROM rnxForumPosts WHERE TopicID=@TopicID", sConnection);
        scomm2.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetFifteenTopicsBy_Page(int iPageNumber, int iBoardID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxForumTopics WHERE TopicID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) TopicID FROM rnxForumTopics WHERE BoardID=@BoardID AND Sticky='False' ORDER BY LastReplyDate DESC) AND BoardID=@BoardID AND Sticky='False' ORDER BY LastReplyDate DESC", sConnection);
        sc.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetStickyTopics(int iBoardID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxForumTopics WHERE BoardID=@BoardID AND Sticky='True' ORDER BY LastReplyDate DESC", sConnection);
        sc.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFiveTopics()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 5 * FROM rnxForumTopics ORDER BY LastReplyDate DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public int GetTopicCountBy_BoardID(int iBoardID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Topic Count' FROM rnxForumTopics WHERE BoardID=@BoardID", sConnection);
        sc.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetLastTopicReplyBy_TopicID(int iTopicID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 1 Author,Date FROM rnxForumPosts WHERE TopicID=@TopicID ORDER BY Date DESC", sConnection);
        sc.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetReplyCountBy_TopicID(int iTopicID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Reply Count' FROM rnxForumPosts WHERE TopicID=@TopicID", sConnection);
        sc.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetForumTopicBy_TopicID(int iTopicID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxForumTopics WHERE TopicID=@TopicID", sConnection);
        sc.Parameters.Add(new SqlParameter("TopicID", iTopicID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= FORUM BOARDS TABLE =-

    public int AddForumBoard(string sTitle, string sDescription, bool bLocked)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxForumBoards VALUES (@Title,@Description,@Locked)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Description", sDescription));
        scomm.Parameters.Add(new SqlParameter("Locked", bLocked));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateForumBoard(int iBoardID, string sTitle, string sDescription, bool bLocked)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxForumBoards SET Title=@Title, Description=@Description, Locked=@Locked WHERE BoardID=@BoardID", sConnection);
        scomm.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Description", sDescription));
        scomm.Parameters.Add(new SqlParameter("Locked", bLocked));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteForumBoard(int iBoardID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxForumBoards WHERE BoardID=@BoardID", sConnection);
        scomm.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetForumBoardTitlesAndIDs()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT BoardID,Title FROM rnxForumBoards ORDER BY BoardID ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetForumBoards()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM rnxForumBoards ORDER BY BoardID ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetForumBoardBy_BoardID(int iBoardID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxForumBoards WHERE BoardID=@BoardID", sConnection);
        sc.Parameters.Add(new SqlParameter("BoardID", iBoardID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= BLOGS TABLE =-

    public int AddBlog(string sAuthorEmail, DateTime dtDate, string sTitle, string sBody, string sAccessLevel)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxBlogs VALUES (@AuthorEmail,@Date,@Title,@Body,@AccessLevel)", sConnection);
        scomm.Parameters.Add(new SqlParameter("AuthorEmail", sAuthorEmail));
        scomm.Parameters.Add(new SqlParameter("Date", dtDate));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("AccessLevel", sAccessLevel));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateBlog(int iBlogID, string sTitle, string sBody, string sAccessLevel)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxBlogs SET Title=@Title, Body=@Body, Level=@AccessLevel WHERE BlogID=@BlogID", sConnection);
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("AccessLevel", sAccessLevel));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteBlog(int iBlogID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxBlogs WHERE BlogID=@BlogID", sConnection);
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlCommand scomm2 = new SqlCommand("DELETE FROM rnxComments WHERE BlogID=@BlogID", sConnection);
        scomm2.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetBlogTitlesAndIDs()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Title,BlogID FROM rnxBlogs ORDER BY Date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFiveBlogsBy_Page(int iPageNumber, string sAccessLevel)
    {
        DataTable dt = new DataTable();
        string sCommand = "SELECT TOP 5 * FROM rnxBlogs WHERE BlogID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*5) BlogID FROM rnxBlogs WHERE Level='Everyone' ORDER BY Date DESC) AND Level='Everyone' ORDER BY Date DESC";
        if (sAccessLevel == "Members Only")
        {
            sCommand = "SELECT TOP 5 * FROM rnxBlogs WHERE BlogID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*5) BlogID FROM rnxBlogs WHERE Level NOT IN ('Group Leaders Only') ORDER BY Date DESC) AND Level NOT IN ('Group Leaders Only') ORDER BY Date DESC";
        }
        else if (sAccessLevel == "Group Leaders Only")
        {
            sCommand = "SELECT TOP 5 * FROM rnxBlogs WHERE BlogID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*5) BlogID FROM rnxBlogs ORDER BY Date DESC) ORDER BY Date DESC";
        }
        SqlCommand sc = new SqlCommand(sCommand, sConnection);
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetLatestBlog()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM rnxBlogs ORDER BY Date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public int GetBlogCount(string sAccessLevel)
    {
        DataTable dt = new DataTable();
        string sCommand = "SELECT COUNT(*)AS 'Blog Count' FROM rnxBlogs WHERE Level='Everyone'";
        if (sAccessLevel == "Members Only")
        {
            sCommand = "SELECT COUNT(*)AS 'Blog Count' FROM rnxBlogs WHERE Level NOT IN ('Group Leaders Only') OR Level='Everyone'";
        }
        else if (sAccessLevel == "Group Leaders Only")
        {
            sCommand = "SELECT COUNT(*)AS 'Blog Count' FROM rnxBlogs";
        }
        SqlDataAdapter sda = new SqlDataAdapter(sCommand, sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetBlogBy_BlogID(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxBlogs WHERE BlogID=@BlogID", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }


    #endregion

    #region -= PODCASTS TABLE =-

    public int AddPodcast(string sTitle, string sDescription, string sURL, DateTime dtDate, int iEpisode, decimal dSize, decimal dLength)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxPodcasts VALUES (@Title,@Description,@URL,@Date,@Episode,@Size,@Length)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Description", sDescription));
        scomm.Parameters.Add(new SqlParameter("URL", sURL));
        scomm.Parameters.Add(new SqlParameter("Date", dtDate));
        scomm.Parameters.Add(new SqlParameter("Episode", iEpisode));
        scomm.Parameters.Add(new SqlParameter("Size", dSize));
        scomm.Parameters.Add(new SqlParameter("Length", dLength));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdatePodcast(int iPodcastID, string sTitle, string sDescription)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxPodcasts SET Title=@Title, Description=@Description WHERE PodcastID=@PodcastID", sConnection);
        scomm.Parameters.Add(new SqlParameter("PodcastID", iPodcastID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Description", sDescription));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeletePodcast(int iPodcastID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxPodcasts WHERE PodcastID=@PodcastID", sConnection);
        scomm.Parameters.Add(new SqlParameter("PodcastID", iPodcastID));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetPodcastEpisodesAndIDs()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Episode,PodcastID FROM rnxPodcasts ORDER BY Date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFivePodcastsBy_Page(int iPageNumber)
    {
        DataTable dt = new DataTable();
        string sCommand = "SELECT TOP 5 * FROM rnxPodcasts WHERE PodcastID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*5) PodcastID FROM rnxPodcasts ORDER BY Date DESC) ORDER BY Date DESC";
        SqlCommand sc = new SqlCommand(sCommand, sConnection);
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetLatestPodcast()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM rnxPodcasts ORDER BY Date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public int GetPodcastCount()
    {
        DataTable dt = new DataTable();
        string sCommand = "SELECT COUNT(*)AS 'Podcast Count' FROM rnxPodcasts";
        SqlDataAdapter sda = new SqlDataAdapter(sCommand, sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetPodcastBy_PodcastID(int iPodcastID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxPodcasts WHERE PodcastID=@PodcastID", sConnection);
        sc.Parameters.Add(new SqlParameter("PodcastID", iPodcastID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }


    #endregion

    #region -= STATIC CONTENT TABLE =-

    public string GetAboutUsContent()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Value FROM rnxStaticContent WHERE VariableName='AboutUsContent'", sConnection);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public int UpdateAboutUsContent(string sContent)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxStaticContent SET Value=@Content WHERE VariableName='AboutUsContent'", sConnection);
        scomm.Parameters.Add(new SqlParameter("Content", sContent));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DateTime GetLastMotivatorDate()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Value FROM rnxStaticContent WHERE VariableName='LastMotivatorDate'", sConnection);
        sda.Fill(dt);
        return Convert.ToDateTime(dt.Rows[0].ItemArray[0].ToString());
    }

    public int UpdateLastMotivatorDate(DateTime dtLastMotivatorDate)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxStaticContent SET Value=@LastMotivatorDate WHERE VariableName='LastMotivatorDate'", sConnection);
        scomm.Parameters.Add(new SqlParameter("LastMotivatorDate", dtLastMotivatorDate.ToString()));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    #endregion

    #region -= MEMBERS TABLE =-

    public int AddMember(string sEmail, string sPassword, string sName, string sPersonalAvatar, string sPhone, string sInterests, string sWebsite, string sPersonalBio, string sBusinessName, string sBusinessLogo, string sBusinessBio, DateTime dtJoinDate, string sAIM, string sMSN, string sYahoo, string sGoogleTalk, string sLocation, string sSignature, bool bAdmin, bool bModerator, bool bCanPostBlog, bool bMemberNewsletter, bool bDailyMotivator, bool bShowEmail, bool bUpdateTwitter, string sTwitterUsername, string sTwitterPassword, string sGender, int iFeedback, DateTime dtBirthday, string sBusinessCategory, string sTwitterFeedStyle, string sArticleCategory, string sSubscriptionID, string sMembership)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxMembers VALUES (@Email,@Password,@Name,@PersonalAvatar,@Phone,@Interests,@Website,@PersonalBio,@BusinessName,@BusinessLogo,@BusinessBio,@JoinDate,@JoinDate,@AIM,@MSN,@Yahoo,@GoogleTalk,@Location,@Signature,@Admin,@Moderator,@CanPostBlog,@MemberNewsletter,@DailyMotivator,@ShowEmail,@UpdateTwitter,@TwitterUsername,@TwitterPassword,@Gender,@Feedback,@Birthday,@BusinessCategory,@TwitterFeedStyle,'False',@ArticleCategory,@SubscriptionID,@Membership,NULL,NULL)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        scomm.Parameters.Add(new SqlParameter("Password", sPassword));
        scomm.Parameters.Add(new SqlParameter("Name", sName));
        scomm.Parameters.Add(new SqlParameter("PersonalAvatar", sPersonalAvatar));
        scomm.Parameters.Add(new SqlParameter("Phone", sPhone));
        scomm.Parameters.Add(new SqlParameter("Interests", sInterests));
        scomm.Parameters.Add(new SqlParameter("Website", sWebsite));
        scomm.Parameters.Add(new SqlParameter("PersonalBio", sPersonalBio));
        scomm.Parameters.Add(new SqlParameter("BusinessName", sBusinessName));
        scomm.Parameters.Add(new SqlParameter("BusinessLogo", sBusinessLogo));
        scomm.Parameters.Add(new SqlParameter("BusinessBio", sBusinessBio));
        scomm.Parameters.Add(new SqlParameter("JoinDate", dtJoinDate));
        scomm.Parameters.Add(new SqlParameter("AIM", sAIM));
        scomm.Parameters.Add(new SqlParameter("MSN", sMSN));
        scomm.Parameters.Add(new SqlParameter("Yahoo", sYahoo));
        scomm.Parameters.Add(new SqlParameter("GoogleTalk", sGoogleTalk));
        scomm.Parameters.Add(new SqlParameter("Location", sLocation));
        scomm.Parameters.Add(new SqlParameter("Signature", sSignature));
        scomm.Parameters.Add(new SqlParameter("Admin", bAdmin));
        scomm.Parameters.Add(new SqlParameter("Moderator", bModerator));
        scomm.Parameters.Add(new SqlParameter("CanPostBlog", bCanPostBlog));
        scomm.Parameters.Add(new SqlParameter("MemberNewsletter", bMemberNewsletter));
        scomm.Parameters.Add(new SqlParameter("DailyMotivator", bDailyMotivator));
        scomm.Parameters.Add(new SqlParameter("ShowEmail", bShowEmail));
        scomm.Parameters.Add(new SqlParameter("UpdateTwitter", bUpdateTwitter));
        scomm.Parameters.Add(new SqlParameter("TwitterUsername", sTwitterUsername));
        scomm.Parameters.Add(new SqlParameter("TwitterPassword", sTwitterPassword));
        scomm.Parameters.Add(new SqlParameter("Gender", sGender));
        scomm.Parameters.Add(new SqlParameter("FeedBack", iFeedback));
        scomm.Parameters.Add(new SqlParameter("Birthday", dtBirthday));
        scomm.Parameters.Add(new SqlParameter("BusinessCategory", sBusinessCategory));
        scomm.Parameters.Add(new SqlParameter("TwitterFeedStyle", sTwitterFeedStyle));
        scomm.Parameters.Add(new SqlParameter("ArticleCategory", sArticleCategory));
        scomm.Parameters.Add(new SqlParameter("SubscriptionID", sSubscriptionID));
        scomm.Parameters.Add(new SqlParameter("Membership", sMembership));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateMember(string sCurrentEmail, string sName, string sPersonalAvatar, string sPhone, string sInterests, string sWebsite, string sPersonalBio, string sBusinessName, string sBusinessLogo, string sBusinessBio, string sAIM, string sMSN, string sYahoo, string sGoogleTalk, string sLocation, string sSignature, bool bAdmin, bool bModerator, bool bCanPostBlog, bool bMemberNewsletter, bool bDailyMotivator, bool bShowEmail, bool bUpdateTwitter, string sTwitterUsername, string sTwitterPassword, string sGender, DateTime dtBirthday, string sBusinessCategory, string sTwitterFeedStyle, string sArticleCategory)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET Name=@Name, PersonalAvatar=@PersonalAvatar, Phone=@Phone, Interests=@Interests, Website=@Website, PersonalBio=@PersonalBio, BusinessName=@BusinessName, BusinessLogo=@BusinessLogo, BusinessBio=@BusinessBio, AIM=@AIM, MSN=@MSN, Yahoo=@Yahoo, GoogleTalk=@GoogleTalk, Location=@Location, Signature=@Signature, Admin=@Admin, Moderator=@Moderator, CanPostBlog=@CanPostBlog, MemberNewsletter=@MemberNewsletter, DailyMotivator=@DailyMotivator, ShowEmail=@ShowEmail, UpdateTwitter=@UpdateTwitter, TwitterUsername=@TwitterUsername, TwitterPassword=@TwitterPassword, Gender=@Gender, Birthday=@Birthday, BusinessCategory=@BusinessCategory, TwitterFeedStyle=@TwitterFeedStyle, ArticleColumn=@ArticleCategory WHERE Email=@CurrentEmail", sConnection);
        scomm.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        scomm.Parameters.Add(new SqlParameter("Name", sName));
        scomm.Parameters.Add(new SqlParameter("PersonalAvatar", sPersonalAvatar));
        scomm.Parameters.Add(new SqlParameter("Phone", sPhone));
        scomm.Parameters.Add(new SqlParameter("Interests", sInterests));
        scomm.Parameters.Add(new SqlParameter("Website", sWebsite));
        scomm.Parameters.Add(new SqlParameter("PersonalBio", sPersonalBio));
        scomm.Parameters.Add(new SqlParameter("BusinessName", sBusinessName));
        scomm.Parameters.Add(new SqlParameter("BusinessLogo", sBusinessLogo));
        scomm.Parameters.Add(new SqlParameter("BusinessBio", sBusinessBio));
        scomm.Parameters.Add(new SqlParameter("AIM", sAIM));
        scomm.Parameters.Add(new SqlParameter("MSN", sMSN));
        scomm.Parameters.Add(new SqlParameter("Yahoo", sYahoo));
        scomm.Parameters.Add(new SqlParameter("GoogleTalk", sGoogleTalk));
        scomm.Parameters.Add(new SqlParameter("Location", sLocation));
        scomm.Parameters.Add(new SqlParameter("Signature", sSignature));
        scomm.Parameters.Add(new SqlParameter("Admin", bAdmin));
        scomm.Parameters.Add(new SqlParameter("Moderator", bModerator));
        scomm.Parameters.Add(new SqlParameter("CanPostBlog", bCanPostBlog));
        scomm.Parameters.Add(new SqlParameter("MemberNewsletter", bMemberNewsletter));
        scomm.Parameters.Add(new SqlParameter("DailyMotivator", bDailyMotivator));
        scomm.Parameters.Add(new SqlParameter("ShowEmail", bShowEmail));
        scomm.Parameters.Add(new SqlParameter("UpdateTwitter", bUpdateTwitter));
        scomm.Parameters.Add(new SqlParameter("TwitterUsername", sTwitterUsername));
        scomm.Parameters.Add(new SqlParameter("TwitterPassword", sTwitterPassword));
        scomm.Parameters.Add(new SqlParameter("Gender", sGender));
        scomm.Parameters.Add(new SqlParameter("Birthday", dtBirthday));
        scomm.Parameters.Add(new SqlParameter("BusinessCategory", sBusinessCategory));
        scomm.Parameters.Add(new SqlParameter("TwitterFeedStyle", sTwitterFeedStyle));
        scomm.Parameters.Add(new SqlParameter("ArticleCategory", sArticleCategory));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateMissionStatements(string sEmail, string sPersonalMissionStatement, string sBusinessMissionStatement)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET PersonalMissionStatement=@PersonalMissionStatement, BusinessMissionStatement=@BusinessMissionStatement WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        scomm.Parameters.Add(new SqlParameter("PersonalMissionStatement", sPersonalMissionStatement));
        scomm.Parameters.Add(new SqlParameter("BusinessMissionStatement", sBusinessMissionStatement));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpgradeMembership(string sEmail, string sSubscriptionID, string sMembership)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET SubscriptionID=@SubscriptionID, Membership=@Membership WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        scomm.Parameters.Add(new SqlParameter("SubscriptionID", sSubscriptionID));
        scomm.Parameters.Add(new SqlParameter("Membership", sMembership));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int AddThumbsUp(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Feedback FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        int iFeedback = Convert.ToInt32(dt.Rows[0].ItemArray[0]);

        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET Feedback=@Feedback WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Feedback", Convert.ToString(++iFeedback)));
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int MinusThumbsUp(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Feedback FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        int iFeedback = Convert.ToInt32(dt.Rows[0].ItemArray[0]);

        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET Feedback=@Feedback WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Feedback", Convert.ToString(--iFeedback)));
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateMemberEmail(string sCurrentEmail, string sNewEmail, string sPersonalAvatar, string sBusinessLogo)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET Email=@NewEmail, PersonalAvatar=@PersonalAvatar, BusinessLogo=@BusinessLogo WHERE Email=@CurrentEmail", sConnection);
        scomm.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        scomm.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm.Parameters.Add(new SqlParameter("PersonalAvatar", sPersonalAvatar));
        scomm.Parameters.Add(new SqlParameter("BusinessLogo", sBusinessLogo));
        SqlCommand scomm2 = new SqlCommand("UPDATE rnxArticles SET Author=@NewEmail WHERE Author=@CurrentEmail", sConnection);
        scomm2.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm2.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm3 = new SqlCommand("UPDATE rnxBlogs SET Author=@NewEmail WHERE Author=@CurrentEmail", sConnection);
        scomm3.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm3.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm4 = new SqlCommand("UPDATE rnxComments SET Author=@NewEmail WHERE Author=@CurrentEmail", sConnection);
        scomm4.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm4.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm5 = new SqlCommand("UPDATE rnxComments SET MemberID=@NewEmail WHERE MemberID=@CurrentEmail", sConnection);
        scomm5.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm5.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm6 = new SqlCommand("UPDATE rnxForumPosts SET Author=@NewEmail WHERE Author=@CurrentEmail", sConnection);
        scomm6.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm6.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm7 = new SqlCommand("UPDATE rnxForumTopics SET Author=@NewEmail WHERE Author=@CurrentEmail", sConnection);
        scomm7.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm7.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm8 = new SqlCommand("UPDATE rnxMemberAds SET MemberID=@NewEmail WHERE MemberID=@CurrentEmail", sConnection);
        scomm8.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm8.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        SqlCommand scomm9 = new SqlCommand("DELETE FROM rnxNonMembers WHERE Email=@NewEmail", sConnection);
        scomm9.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm9.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        iRowsAffected += scomm2.ExecuteNonQuery();
        iRowsAffected += scomm3.ExecuteNonQuery();
        iRowsAffected += scomm4.ExecuteNonQuery();
        iRowsAffected += scomm5.ExecuteNonQuery();
        iRowsAffected += scomm6.ExecuteNonQuery();
        iRowsAffected += scomm7.ExecuteNonQuery();
        iRowsAffected += scomm8.ExecuteNonQuery();
        iRowsAffected += scomm9.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateMemberPassword(string sEmail, string sNewPassword)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET Password=@NewPassword WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        scomm.Parameters.Add(new SqlParameter("NewPassword", sNewPassword));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateLastLogin(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET LastLogin='" + DateTime.Now.ToString() + "' WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteMember(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxMembers SET Deleted='True' WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetMissonStatements(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT PersonalMissionStatement,BusinessMissionStatement FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetMemberNamesAndEmails()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Name,Email FROM rnxMembers WHERE Deleted='False' ORDER BY Name ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetMemberNamesAndEmailsBy_SearchTerm(string sSearchTerm)
    {
        sSearchTerm = sSearchTerm.Replace(' ', '%');
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Name,Email FROM rnxMembers WHERE ((Email LIKE (@SearchTerm)) OR (Name LIKE (@SearchTerm))) AND Deleted='False' ORDER BY Name ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("SearchTerm", "%" + sSearchTerm + "%"));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetArticleAuthorNamesAndEmails()
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Name,Email FROM rnxMembers WHERE Deleted='False' AND ArticleColumn NOT IN ('None') ORDER BY Name ASC", sConnection);
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetRandomMember()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM rnxMembers WHERE Deleted='False' AND PersonalAvatar NOT IN ('no_avatar.gif') ORDER BY NEWID()", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetMemberBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public string GetMembershipStatusBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Membership FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public string GetSubscriptionIDBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT SubscriptionID FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public DataTable GetFifteenBusinessesBy_BusinessCategory(string sCategory, int iPageNumber)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 Email, BusinessName, BusinessLogo, Name, Location, Website FROM rnxMembers WHERE Email NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) Email FROM rnxMembers WHERE BusinessCategory=@Category AND BusinessName NOT IN ('') AND Deleted='False' ORDER BY BusinessName) AND BusinessCategory=@Category AND BusinessName NOT IN ('') AND Deleted='False' ORDER BY BusinessName", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public int GetBusinessCountBy_Category(string sCategory)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(DISTINCT BusinessName) AS 'Business Count' FROM rnxMembers WHERE BusinessCategory=@Category AND BusinessName NOT IN ('') AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("Category", sCategory));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public int GetMemberCountBy_SearchTerm(string sSearchTerm)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Member Count' FROM rnxMembers WHERE Name LIKE @SearchTerm AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("SearchTerm", "%" + sSearchTerm + "%"));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetFifteenMembersAlphabeticallyBy_SearchTerm(string sSearchTerm, int iPageNumber)
    {
        sSearchTerm = sSearchTerm.Replace(' ', '%');
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxMembers WHERE Email NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) Email FROM rnxMembers WHERE Name LIKE @SearchTerm AND Deleted='False' ORDER BY Name) AND Name LIKE @SearchTerm AND Deleted='False' ORDER BY Name", sConnection);
        sc.Parameters.Add(new SqlParameter("SearchTerm", "%" + sSearchTerm + "%"));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFifteenMembersLastLoginBy_SearchTerm(string sSearchTerm, int iPageNumber)
    {
        sSearchTerm = sSearchTerm.Replace(' ', '%');
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxMembers WHERE Email NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) Email FROM rnxMembers WHERE Name LIKE @SearchTerm AND Deleted='False' ORDER BY LastLogin DESC, Name ASC) AND Name LIKE @SearchTerm AND Deleted='False' ORDER BY LastLogin DESC, Name ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("SearchTerm", "%" + sSearchTerm + "%"));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetFifteenMembersPopularityBy_SearchTerm(string sSearchTerm, int iPageNumber)
    {
        sSearchTerm = sSearchTerm.Replace(' ', '%');
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT TOP 15 * FROM rnxMembers WHERE Email NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*15) Email FROM rnxMembers WHERE Name LIKE @SearchTerm AND Deleted='False' ORDER BY Feedback DESC, Name ASC) AND Name LIKE @SearchTerm AND Deleted='False' ORDER BY Feedback DESC, Name ASC", sConnection);
        sc.Parameters.Add(new SqlParameter("SearchTerm", "%" + sSearchTerm + "%"));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public string GetMemberPasswordBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Password FROM rnxMembers WHERE Email=@Email AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public string GetMemberNameBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Name FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        string sName = dt.Rows[0].ItemArray[0].ToString();
        try
        {
            sName = dt.Rows[0].ItemArray[0].ToString().Remove(dt.Rows[0].ItemArray[0].ToString().IndexOf(' '));
        }
        catch
        {

        }
        return sName;
    }

    public string GetFullMemberNameBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Name FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public DataTable GetAllNewsletterSubscribedMembers()
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Name, Email FROM rnxMembers WHERE MemberNewsletter='True' AND Deleted='False'", sConnection);
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetAllMotivatorSubscribedMembers()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Name, Email FROM rnxMembers WHERE DailyMotivator='True' AND Deleted='False'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public bool IsMemberAdmin(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Admin FROM rnxMembers WHERE Email=@Email AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToBoolean(dt.Rows[0].ItemArray[0]);
    }

    public bool IsMemberModerator(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Moderator FROM rnxMembers WHERE Email=@Email AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToBoolean(dt.Rows[0].ItemArray[0]);
    }

    public bool CanMemberPostBlog(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT CanPostBlog FROM rnxMembers WHERE Email=@Email AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToBoolean(dt.Rows[0].ItemArray[0]);
    }

    public string MemberArticleColumn(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT ArticleColumn FROM rnxMembers WHERE Email=@Email AND Deleted='False'", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public bool EmailExists(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Email Count' FROM rnxMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region -= NON-MEMBERS TABLE =-

    public int AddNonMember(string sEmail, string sName, bool bDailyMotivator, bool bNonMemberNewsletter)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxNonMembers VALUES (@Email,@Name,@DailyMotivator,@NonMemberNewsletter)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        scomm.Parameters.Add(new SqlParameter("Name", sName));
        scomm.Parameters.Add(new SqlParameter("DailyMotivator", bDailyMotivator));
        scomm.Parameters.Add(new SqlParameter("NonMemberNewsletter", bNonMemberNewsletter));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdateNonMember(string sCurrentEmail, string sNewEmail, string sName, bool bDailyMotivator, bool bNonMemberNewsletter)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxNonMembers SET Email='" + sNewEmail + "', Name='" + sName + "', DailyMotivator='" + bDailyMotivator.ToString() + "', NonMemberNewsletter='" + bNonMemberNewsletter.ToString() + "' WHERE Email='" + sCurrentEmail + "'", sConnection);
        scomm.Parameters.Add(new SqlParameter("CurrentEmail", sCurrentEmail));
        scomm.Parameters.Add(new SqlParameter("NewEmail", sNewEmail));
        scomm.Parameters.Add(new SqlParameter("Name", sName));
        scomm.Parameters.Add(new SqlParameter("DailyMotivator", bDailyMotivator));
        scomm.Parameters.Add(new SqlParameter("NonMemberNewsletter", bNonMemberNewsletter));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UnsubscribeNonMemberNewsletter(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxNonMembers SET NonMemberNewsletter='False' WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UnsubscribeNonMemberDailyMotivator(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("UPDATE rnxNonMembers SET DailyMotivator='False' WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteNonMember(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM rnxNonMembers WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public string GetNonMemberNameBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT Name FROM rnxNonMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        string sName = dt.Rows[0].ItemArray[0].ToString();
        try
        {
            sName = dt.Rows[0].ItemArray[0].ToString().Remove(dt.Rows[0].ItemArray[0].ToString().IndexOf(' '));
        }
        catch
        {

        }
        return sName;
    }

    public DataTable GetNonMemberNamesAndEmails()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Name,Email FROM rnxNonMembers ORDER BY Name ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetNonMemberBy_Email(string sEmail)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxNonMembers WHERE Email=@Email", sConnection);
        sc.Parameters.Add(new SqlParameter("Email", sEmail));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetAllNewsletterSubscribedNonMembers()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Name, Email FROM rnxNonMembers WHERE NonMemberNewsletter='True'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetAllMotivatorSubscribedNonMembers()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Name, Email FROM rnxNonMembers WHERE DailyMotivator='True'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    #region -= MEMBER NEWSLETTERS TABLE =-

    public int AddNewsletter(DateTime dtSentDate, string sTitle, string sBody)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO rnxMemberNewsletters VALUES (@SentDate,@Title,@Body)", sConnection);
        scomm.Parameters.Add(new SqlParameter("SentDate", dtSentDate));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetTenNewslettersBy_Page(int iPageNumber)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 10 * FROM rnxMemberNewsletters WHERE NewsletterID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*10) NewsletterID FROM rnxMemberNewsletters ORDER BY SentDate DESC) ORDER BY SentDate DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public int GetNewsletterCount()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)AS 'Newsletter Count' FROM rnxMemberNewsletters", sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public DataTable GetNewsletterBy_NewsletterID(int iNewsletterID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM rnxMemberNewsletters WHERE NewsletterID=@NewsletterID", sConnection);
        sc.Parameters.Add(new SqlParameter("NewsletterID", iNewsletterID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    public DataSet CustomQuery(SqlCommand sQuery)
    {
        sQuery.Connection = sConnection;
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sQuery);
        sda.Fill(ds);
        return ds;
    }

}
