using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Facebook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appFacebook
{
    public partial class Form1 : Form
    {
        String name = "";
        String id = "";
        String link = "";
        String picture = "";
        String aboutMe = "";
        String likes = "";
        String token = "987518644615633|UNhNiU-6DpGWb1oha5OVsb2v7Cg";

        List<Post> postsList = new List<Post>();

        public Form1()
        {
            InitializeComponent();
            txtToken.Text = token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cleanData();
            findDAta(txtQuery.Text);
            loadData(); 
        }

        public void findDAta(String query)
        {
            try
            {
                var accessToken = txtToken.Text;
                var client = new FacebookClient(accessToken);
                dynamic me = client.Get(query);
                id = me.id;
                name = me.name;
                link = me.link;
                aboutMe = me.about;
                likes = Convert.ToString(me.likes);
                ArrayList pictures = new ArrayList();
                var dat = me.cover;
                picture = dat.source;
                var post=me.post;


                dynamic result2 = client.Get("https://graph.facebook.com/" + query + "/posts");

               


                
               foreach (dynamic var in result2.data)
               {
                   Post oPost = new Post();
                   oPost.id = var.id;
                   oPost.message = var.message;
                   oPost.link=var.link;
                   oPost.shares = "0";

                   try
                   {
                       oPost.shares = Convert.ToString(var.shares[0]);
                   }
                   catch (Exception ex)
                   {

                   }

                   
                   //oPost.shares =Convert.ToString(var.shares[0]);

                   dynamic result3 = client.Get(oPost.id+"/?fields=likes");
                   String lenthg = "0";

                   try
                   {
                       var ox = result3.likes.data;
                       lenthg = Convert.ToString(ox.Count);
                   }catch(Exception ex)
                   {

                   }



                   oPost.likes = lenthg;

                   postsList.Add(oPost);
               }





               /*dynamic result = client.Get(query + "/posts");

                for (int i = 0; i < result.Count; i++)
                {
                    Posts posts = new Posts();

                    posts.PostId = result.data[i].id;
                    if (object.ReferenceEquals(result.data[i].story, null))
                        posts.PostStory = "this story is null";
                    else
                        posts.PostStory = result.data[i].story;
                    if (object.ReferenceEquals(result.data[i].message, null))
                        posts.PostMessage = "this message is null";
                    else
                        posts.PostMessage = result.data[i].message;

                    posts.PostPicture = result.data[i].picture;
                    posts.UserId = result.data[i].from.id;
                    posts.UserName = result.data[i].from.name;

                    postsList.Add(posts);
                }*/

            }catch(Exception ex)
            {

            }

        } 

        public void loadData()
        {
            txtName.Text = name;
            txtLink.Text = link;
            pictureBox1.ImageLocation = picture;
            txtAbout.Text = aboutMe;
            txtLikes.Text = likes;
            loadList();
        }

        public void cleanData()
        {
             id = "";
             name = "";
             link = "";
             picture = "";
             aboutMe = "";
             likes = "";
             postsList.Clear();
        }


        public void loadList()
        {
            richTextBox1.Clear();
            
            foreach (var item in postsList)
            {

                richTextBox1.Text += "ID=> " + item.id + "\nLINK=> " + item.link + "\nLIKES=> " + item.likes + "\nSHARES=> " + item.shares + "\nMESSAGE=> " + item.message + "\n------------------------------\n";
                
              
            }
          
        }

    }


}
