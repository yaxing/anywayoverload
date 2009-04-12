using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Text;
using BsCtrl;

public partial class manage_bookManage : System.Web.UI.Page
{
    String DbConnectString = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("adminLogin.html");
        }
        if (!IsPostBack)
        {
            BsBookInfo bookInfo = new BsBookInfo(DbConnectString);
            DataSet ds = bookInfo.GetBookClassify();
            DataSet ds1 = new DataSet();
            ds1 = bookInfo.GetAllBooks();
            DDLType_Load(ds);
            LBEx_Load(ds);
            LBNew_Load();
            BookGridView_Load(ds1);
        }
    }
    protected void DDLType_Load(DataSet ds)
    {
        DDDLType.DataSource = ds;
        DDDLType.DataValueField = ds.Tables[0].Columns[0].ToString();
        DDDLType.DataTextField = ds.Tables[0].Columns[1].ToString();
        DDDLType.DataBind();
    }
    protected void LBEx_Load(DataSet ds)
    {
        LBEx.DataSource = ds;
        LBEx.DataValueField = ds.Tables[0].Columns[0].ToString();
        LBEx.DataTextField = ds.Tables[0].Columns[1].ToString();
        LBEx.DataBind();
    }
    protected void LBNew_Load()
    {
        FileStream fs = new FileStream(Server.MapPath("BookType.xml"), FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        DataSet ds = new DataSet();
        ds.ReadXml(sr);
        this.LBNew.DataSource = ds.Tables[0];
        this.LBNew.DataValueField = ds.Tables[0].Columns[0].ToString();
        this.LBNew.DataTextField = ds.Tables[0].Columns[1].ToString();
        this.LBNew.DataBind();
        fs.Close();
    }
    protected void BookGridView_Load(DataSet ds)
    {
        this.BookGridView.DataSource = ds;
        this.BookGridView.DataKeyNames = new string[] {"ID"};
        this.BookGridView.DataBind();
    }
    protected void NewBook_Click(object sender, ImageClickEventArgs e)
    {
        NewBookPanel.Visible = true;
        BookSearchPanel.Visible = false;
        BookListPanel.Visible = false;
        TypePanel.Visible = false;
        BookUpdatePanel.Visible = false;
    }
    protected void NewType_Click(object sender, ImageClickEventArgs e)
    {
        if(Session["AdminLv"].ToString()=="1")
        {
            Response.Write("<script language='javascript'>alert('���ĵȼ��޷�ʹ�ñ����ܡ�');</script>");
            return;
        }
        NewBookPanel.Visible = false;
        BookListPanel.Visible = false;
        TypePanel.Visible = true;
        BookUpdatePanel.Visible = false;
        BookSearchPanel.Visible = false;
    }
    protected void BookList_Click(object sender, ImageClickEventArgs e)
    {
        BsBookInfo bookInfo = new BsBookInfo(DbConnectString);
        DataSet ds = new DataSet();
        ds = bookInfo.GetAllBooks();
        BookGridView_Load(ds);
        NewBookPanel.Visible = false;
        BookListPanel.Visible = true;
        TypePanel.Visible = false;
        BookUpdatePanel.Visible = false;
        BookSearchPanel.Visible = false;
    }
    protected void BookUpdate_Click(object sender, ImageClickEventArgs e)
    {
        NewBookPanel.Visible = false;
        BookListPanel.Visible = false;
        TypePanel.Visible = false;
        BookUpdatePanel.Visible = false;
        BookSearchPanel.Visible = true;
    }
    protected void BtnSub_Click(object sender, EventArgs e)
    {
        String fileName = null;
        String typeName = null;
        String CoverPath = null;
        if (this.CoverUpload.HasFile)
        {
            fileName = this.CoverUpload.PostedFile.FileName.Substring(this.CoverUpload.PostedFile.FileName.LastIndexOf("\\") + 1);
            typeName = this.CoverUpload.PostedFile.FileName.Substring(this.CoverUpload.PostedFile.FileName.LastIndexOf(".") + 1);   
            if (typeName != "JPG" && typeName != "BMP" && typeName != "GIF" && typeName != "PNG" && typeName != "jpg" && typeName != "bmp" && typeName != "gif" && typeName != "png")
            {
                Response.Write("<script language='javascript'>alert('���ϴ�ͼƬ�ļ���');</script>");
            }
            else
            {
                this.CoverUpload.PostedFile.SaveAs(Server.MapPath("..\\cover") + "\\" + fileName);
                CoverPath = "cover\\" + fileName;
            }
        }
        if (CoverPath == null||CoverPath == "cover\\") CoverPath = "";
        String ISBN = this.TxtISBN.Text;
        String bookName = this.TxtBookName.Text;
        String author = this.TxtAuthor.Text;
        String pub = this.TxtPub.Text;
        String pubTime = this.TxtPubTime.Text;
        String price = this.TxtPrice.Text;
        String quan = this.TxtQuantity.Text;
        String script = this.TxtScript.Text;
        script = script.Replace("\r\n", "<br/>");
        String bookType = this.DDDLType.SelectedValue;
        BsBookInfo bookIn = new BsBookInfo(DbConnectString);
        if (bookIn.InsertNewBook(bookName, bookType, author, pub, pubTime, ISBN, price, quan, CoverPath, script) && bookIn.UpdateBookType(bookType,1))
        {
            Response.Write("<script language='javascript'>alert('��ӳɹ���');location.href('bookManage.aspx');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('���ʧ�ܡ���������ӡ�');</script>");
        }
    }

    
    protected void BtnAddP_Click(object sender, EventArgs e)
    {
        String TypeName = this.TxtTypeP.Text;
        BsBookInfo bookType = new BsBookInfo(DbConnectString);
        if(bookType.InsertNewBookType(TypeName))
        {
            this.lblStat.Text = "�·�����ӳɹ�";
            DataSet ds = bookType.GetBookClassify();
            LBEx_Load(ds);
            DDLType_Load(ds);
        }
        else
        {
            this.lblStat.Text = "���ʧ��,���������";
        }
    }
    protected void BtnDelP_Click(object sender, EventArgs e)
    {
        String TypeName = this.TxtTypeP.Text;
        BsBookInfo bookType = new BsBookInfo(DbConnectString);
        if(bookType.DeleteBookType(TypeName))
        {
            this.lblStat.Text = "����ɾ���ɹ�";
            DataSet ds = bookType.GetBookClassify();
            LBEx_Load(ds);
            DDLType_Load(ds);
        }
        else
        {
            this.lblStat.Text = "ɾ��ʧ��,��ȷ���÷���û���鼮";
        }         
    }
    protected void BookGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["AdminLv"].ToString() == "1")
        {
            Response.Write("<script language='javascript'>alert('���ĵȼ��޷�ʹ�ñ����ܡ�');</script>");
            return;
        }

        DataKey key = this.BookGridView.DataKeys[e.RowIndex];
        String bookID = key[0].ToString();
        int bookIDI = Convert.ToInt32(key[0]);
        BsBookInfo bookInfo = new BsBookInfo(DbConnectString);
        DataSet ds = new DataSet();
        ds = bookInfo.GetBookInfo(bookIDI);
        String ImgPath = ds.Tables[0].Rows[0][13].ToString();
        String bookType = ds.Tables[0].Rows[0][0].ToString();
        String fileName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1);
        if(bookInfo.DeleteOneBook(bookID) && bookInfo.UpdateBookType(bookType,2))
        {
            if (ImgPath != "cover\\ASPgcyyysj.gif" && File.Exists(Server.MapPath("..\\cover") + "\\" + fileName))
            {
               File.Delete(Server.MapPath("..\\cover") + "\\" + fileName);  
            }
            Response.Write("<script language='javascript'>alert('ɾ���ɹ�');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('ɾ��ʧ�ܣ����ݲ���ʧ�ܣ���ȷ�����ݿ��Ƿ�����������');</script>");
        }
        ds = bookInfo.GetAllBooks();
        BookGridView_Load(ds);
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        String bookSearch = this.TxtBookSearch.Text;
        BsBookInfo bookInfo = new BsBookInfo(DbConnectString);
        DataSet ds = new DataSet();
        ds = bookInfo.GetFamiliarBooks(bookSearch);
        BookGridView_Load(ds);
        NewBookPanel.Visible = false;
        BookListPanel.Visible = true;
        TypePanel.Visible = false;
        BookUpdatePanel.Visible = false;
        BookSearchPanel.Visible = false;
    }

    protected void BookGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataKey key = this.BookGridView.DataKeys[e.NewEditIndex];
        int bookID = Convert.ToInt32(key[0]);
        BsBookInfo bookInfo = new BsBookInfo(DbConnectString);
        DataSet ds = new DataSet();
        ds = bookInfo.GetBookInfo(bookID);
        this.TxtBookNameU.Text = ds.Tables[0].Rows[0][6].ToString();
        DDLTypeU_Load(bookInfo);
        this.DDLTypeU.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        this.TxtAuthorU.Text = ds.Tables[0].Rows[0][8].ToString();
        this.TxtISBNU.Text = ds.Tables[0].Rows[0][4].ToString();
        this.TxtPubU.Text = ds.Tables[0].Rows[0][7].ToString();
        String pubDate = ds.Tables[0].Rows[0][11].ToString();
        int dateIndex = pubDate.LastIndexOf(" ");
        this.TxtPubDateU.Text = pubDate.Substring(0,dateIndex);
        this.TxtPriceU.Text = ds.Tables[0].Rows[0][10].ToString();
        this.TxtAvailableU.Text = ds.Tables[0].Rows[0][14].ToString();
        String bookScript = ds.Tables[0].Rows[0][9].ToString();
        this.TxtScriptU.Text = bookScript.Replace("<br/>", "\r\n");
        this.ImgEx.ImageUrl = "..\\"+ds.Tables[0].Rows[0][13].ToString();
        this.HFBookID.Value = ds.Tables[0].Rows[0][3].ToString();
        this.HFOldType.Value = ds.Tables[0].Rows[0][0].ToString();
        this.TxtDisc.Text = ds.Tables[0].Rows[0][19].ToString();

        NewBookPanel.Visible = false;
        BookListPanel.Visible = false;
        TypePanel.Visible = false;
        BookUpdatePanel.Visible = true;
        BookSearchPanel.Visible = false;
    }

    protected void DDLTypeU_Load(BsBookInfo bookInfo)
    {
        DataSet ds = bookInfo.GetBookClassify();
        this.DDLTypeU.DataSource = ds;
        this.DDLTypeU.DataValueField = ds.Tables[0].Columns[0].ToString();
        this.DDLTypeU.DataTextField = ds.Tables[0].Columns[1].ToString();
        this.DDLTypeU.DataBind();
    }

    protected void BtnUpdate_Click (object sender, EventArgs e)
    {
        String fileName = null;
        String typeName = null;
        String CoverPath = null;
        String ISBN = this.TxtISBNU.Text;
        String bookName = this.TxtBookNameU.Text;
        String author = this.TxtAuthorU.Text;
        String pub = this.TxtPubU.Text;
        String pubTime = this.TxtPubDateU.Text;
        String price = this.TxtPriceU.Text;
        String quan = this.TxtAvailableU.Text;
        String script = this.TxtScriptU.Text;
        script = script.Replace("\r\n", "<br/>");
        String bookType = this.DDLTypeU.SelectedValue;
        String bookID = this.HFBookID.Value;
        String OldType = this.HFOldType.Value;
        String bookDis = this.TxtDisc.Text;
        if (this.CoverUploadU.HasFile)
        {
            fileName = this.CoverUploadU.PostedFile.FileName.Substring(this.CoverUploadU.PostedFile.FileName.LastIndexOf("\\") + 1);
            typeName = this.CoverUploadU.PostedFile.FileName.Substring(this.CoverUploadU.PostedFile.FileName.LastIndexOf(".") + 1);
            if (typeName != "JPG" && typeName != "BMP" && typeName != "GIF" && typeName != "PNG" && typeName != "jpg" && typeName != "bmp" && typeName != "gif" && typeName != "png")
            {
                Response.Write("<script language='javascript'>alert('���ϴ�ͼƬ�ļ���');</script>");
            }
            else
            {
                this.CoverUploadU.PostedFile.SaveAs(Server.MapPath("..\\cover") + "\\" + fileName);
                CoverPath = "cover\\" + fileName;
            }
        }
        else
        {
            CoverPath = this.ImgEx.ImageUrl.Substring(3);
        }
        BsBookInfo bookIn = new BsBookInfo(DbConnectString);
        if (bookIn.UpdateOneBook(bookID, bookName, bookType, author, pub, pubTime, ISBN, price, quan, CoverPath, script,bookDis) && bookIn.UpdateBookType(bookType, OldType))
        {
            Response.Write("<script language='javascript'>alert('���³ɹ���');location.href('bookManage.aspx');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('����ʧ�ܡ���������ӡ�');</script>");
        }
    }
    protected void BookGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.BookGridView.PageIndex = e.NewPageIndex;
        BsBookInfo bookInfo = new BsBookInfo(DbConnectString);
        DataSet ds = new DataSet();
        ds = bookInfo.GetAllBooks();
        this.BookGridView_Load(ds);
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        String TypeName = this.LBNew.SelectedValue.ToString();
        if (TypeName == "(��ѡ����)"||TypeName == ""||TypeName == null)
        {
            if (TypeName == "(��ѡ����)")
            {
                this.lblStat.Text = "(��ѡ����)Ϊ��ʾ�ֶΣ����ܽ��в���";
            }
            else
            {
                this.lblStat.Text = "������ӿշ���";
            }
            return;
        }
        String filePath = Server.MapPath("BookType.xml");

        BsBookInfo bookType = new BsBookInfo(DbConnectString);
        if (bookType.InsertNewBookType(TypeName)&&bookType.DeleteFromXML(TypeName,filePath))
        {
            this.lblStat.Text = "�·�����ӳɹ�";
            DataSet ds = bookType.GetBookClassify();
            LBEx_Load(ds);
            DDLType_Load(ds);
        }
        else
        {
            this.lblStat.Text = "���ʧ��,���������";
            return;
        }

        LBNew_Load();

    }

    protected void BtnDel_Click(object sender, EventArgs e)
    {
        String TypeName = this.LBEx.SelectedValue.ToString();
        if (TypeName == "" || TypeName == null)
        {
            this.lblStat.Text = "��ѡ��Ҫɾ���ķ���";
            return;
        }
        TypeName = this.LBEx.SelectedItem.Text.ToString();
        String filePath = Server.MapPath("BookType.xml");

        BsBookInfo bookType = new BsBookInfo(DbConnectString);
        if (bookType.DeleteBookType(TypeName)&&bookType.WriteToXML(TypeName,filePath))
        {
            this.lblStat.Text = "����ɾ���ɹ�";
            DataSet ds = bookType.GetBookClassify();
            LBEx_Load(ds);
            DDLType_Load(ds);
        }
        else
        {
            this.lblStat.Text = "ɾ��ʧ��,��ȷ���÷���û���鼮";
            return;
        }

        LBNew_Load();

    }
}
