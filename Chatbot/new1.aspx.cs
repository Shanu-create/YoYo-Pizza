using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Chatbot
{
    public partial class new1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DFQ9S5UM\\SQLEXPRESS;Database=chatbot;Integrated Security=true");
        string[] databasecontents = { "orderid", "name", "mobile", "email", "item", "order_time" };

        public static string search_id;
        public static int overallcount = 0;
        public static bool flag = false;
        public static int statuscheckingprocess;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            Label2.Text = overallcount.ToString();
            bool found = false;
        
           
            string input = TextBox1.Text;
            TextBox1.Text = "";
            string text = input.ToLower();
            
            string product = null;
            string[,] newarray = new string[19, 2] { { "hi", "Hello!.....Welcome to YOYO PIZZZA How can i help you?Order pizza or Check status" },
                { "hru", "fine" },
                {"order pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?" },
                {"pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?" },
                {"i want menu","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?" },
                {"i want pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?" },
                { "menu please","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"},
                {"pizza please","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"},
                {"show me the menu","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?" },
                {"give me pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?" },
                {"cheese pizza","Great choice....Your Cheese pizza is getting ready \nEnter ok to confirm you order "},
                {"veg pizza","Great choice....Your Veg pizza is getting ready \nEnter ok to confirm you order "},
                {"italian pizza", "Great choice....Your Italian pizza is getting ready \nEnter ok to confirm you order "},
                {"chicken pizza", "Great choice....Your Chicken pizza is getting ready \nEnter ok to confirm you order " },
                {"mushroom pizza","Great choice....Your Mushroom pizza is getting ready \nEnter ok to confirm you order "},
                {"paneer pizza","Great choice....Your Paneer pizza is getting ready \nEnter ok to confirm you order " },
                {"status","Enter 'yes' to know status"},
                {"check status","Enter 'yes' to know status"},
                {"i want to know the status","Enter 'yes' to know status"}};


            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (text == newarray[i, j])
                    {
                        product = newarray[i, j + 1];
                        if (text == "cheese pizza" || text == "veg pizza" || text == "italian pizza" || text == "chicken pizza" || text == "mushroom pizza" || text == "paneer pizza")
                        {
                            databasecontents[4] = text;
                        }
                        found = true;
                    }
                }
            }

            if (text == "ok" && found == false)
            {
                product = "Enter your name";
                overallcount = 0;

            }
            else if (text == "yes" && found == false)
            {
                flag = true;
                product = "Enter your order id";
 
            }
            else
            {
                if (overallcount == 0 && found == false && flag==false)
                {
                  //  Label2.Text = overallcount.ToString();
                    databasecontents[1] = text;
                    product = "Enter your mobile no";
                
                    // Response.Write("<script>alert(overallcount)</script>");
                    overallcount=1;
                   //Label2.Text = overallcount.ToString();


                }
                else if (overallcount == 1 && found == false && flag == false)
                {
                   // Label2.Text = overallcount.ToString();
                    databasecontents[2] = text;
                    product = "Enter your emailid";
                    overallcount=2;
                    
                    //Label2.Text = overallcount.ToString();
                }
                else if (overallcount == 2 && found == false && flag == false)
                {
                  //  Label2.Text = overallcount.ToString();
                    string orderid;
                    databasecontents[3] = text;
                   // orderid=random.Next(1000);
                    //orderid = Math.floor((Math.random() * 999) + 100);
                    Random r = new Random();
                    orderid = r.Next(10, 50).ToString();
                    databasecontents[0] = orderid;
                    //string d = new Date().toLocaleTimeString();
                    DateTime now = DateTime.Now;
                    string d = now.ToString();
                    databasecontents[5] = d;
                    product = "Your orderID is " + orderid + "\nThank you for shopping...";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into order_details values('"+databasecontents[0]+"','"+ databasecontents[1] + "','"+ databasecontents[2] + "','"+ databasecontents[3] + "','"+ databasecontents[4] + "','"+ databasecontents[5] + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                }

            }

            search_id = text;
            if (statuscheckingprocess == 1 && flag==true)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from order_details where order_id='" + search_id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
             
                    product = "Your order is out for delievery";
                }
                else
                {
                    product = "Order not placed";
                }
            }
            if (flag == true)
            {
                statuscheckingprocess = 1;
                
            }


                Label1.Text = product;
        }
    }
}



//==================
//search from databse 
//calculate current_time - order_time
//display the status
/*
let d5 = new Date().toLocaleTimeString();
let time1 = d5.split(':');
let time2 = current_status1.split(':');
let minutes = Math.abs(Number(time1[1]) - Number(time2[1]));
let hours = Math.floor(parseInt(minutes / 60));
hours = Math.abs(Number(time1[0]) - Number(time2[0]) - hours);
minutes = minutes % 60;
if (hours.toString().length == 1) {
   hours = '0' + hours;
}
if (minutes.toString().length == 1) {
   minutes = '0' + minutes;
}
if (hours <= "00" && minutes <= "15") {

   product="Your order is placed just now and it will be deleived soon";

}
else if (hours <= "00" && minutes >= "15" && minutes <= "30") {   
   product="Your order will reach you very soon";

}
else if (hours <= "00" && minutes >= "30" && minutes <= "45") {
   product="Your order is deleivered successfully..";

}
*/
//      product = "your order is out for delievery";
// }
