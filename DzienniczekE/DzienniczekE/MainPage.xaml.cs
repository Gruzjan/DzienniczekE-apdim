using DzienniczekE.Data;
using DzienniczekE.Models;
using DzienniczekE.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DzienniczekE
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var model = new MainPageViewModel();

            using (var db = new ApplicationDbContext())
            {
                model.Students = db.Students.ToList();
            }

            //sample students TODO: remove
            model.Students.Add(new Student
            {
                FirstName = "Gracjan",
                LastName = "Wu",
                StudentId = 27
            });
            
            model.Students.Add(new Student
            {
                FirstName = "siema",
                LastName = "Siema",
                StudentId = 235
            });

            //
            BindingContext = model;
        }

        private async void OnNewBtn_Click(object sender, EventArgs e) 
        {
            using (var db = new ApplicationDbContext())
            {
                db.Students.Add(new Student
                {
                    FirstName = "Dupa",
                    LastName = "Dupa"
                });

                await db.SaveChangesAsync();
            }
        }
    }
}
