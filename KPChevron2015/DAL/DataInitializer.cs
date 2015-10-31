using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KPChevron2015.Models;

namespace KPChevron2015.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //User
            var users = new List<User>
            {
                new User
                {
                    Name = "Muhammad Fathir Irhas",
                    Email = "fathir.irhas@outlook.com",
                    UpdateBy = "Admin",
                    UpdateDate = DateTime.Parse("2015-12-12")

                }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
            //end

            //Role
            var roles = new List<Role>
            {
                new Role
                {
                    RoleID = "R002",
                    RoleName = "PIC",
                    RoleDesc = "Person In Charge",
                    UpdateBy = "Admin",
                    UpdateDate = DateTime.Parse("2015-12-12")
                }
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();
            //end

            //Enrollement
            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    EnrollmentID = "E001",
                    UserID = 1,
                    RoleID = "R002",
                    Name = "Muhammad Fathir Irhas",
                    RoleName = "PIC",
                    Team = "A",
                    Username = "fathir",
                    Password = "asd",
                    UpdateBy = "admin",
                    UpdateDate = DateTime.Parse("2015-12-12")
                    
                }
            };
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
            //end

            //Contractor
            var contractors = new List<Contractor>
            {
                new Contractor
                {
                    ContractorID = "C001",
                    ContractorName = "Tripatra",
                    Remark = "Remark"
                }
            };
            contractors.ForEach(c => context.Contractors.Add(c));
            context.SaveChanges();
            //end

            //General Parameter
            var generalparameters = new List<GeneralParameter>
            {
                new GeneralParameter
                {
                    GeneralParameterID = "PE",
                    ParameterDesc = "Petroleum Engineer",
                    UpdateBy = "Admin",
                    UpdateDate = DateTime.Parse("2015-12-12")
                }
            };
            generalparameters.ForEach(g => context.GeneralParameters.Add(g));
            context.SaveChanges();
            //end

            //Well
            var wells = new List<Well>
            {
                new Well
                {
                    WellID = "W001",
                    WellName = "Sumur A",
                    Location = "Sibayak",
                    Area = "A125",
                    LastSurveyType = "BUP",
                    LastSurveyDate = DateTime.Parse("2015-12-12")
                },

                new Well
                {
                    WellID = "W002",
                    WellName = "Sumur B",
                    Location = "Merapi",
                    Area = "A126",
                    LastSurveyType = "BMP",
                    LastSurveyDate = DateTime.Parse("2015-12-12")
                },

                new Well
                {
                    WellID = "W003",
                    WellName = "Sumur C",
                    Location = "Merapi",
                    Area = "A127",
                    LastSurveyType = "BUP",
                    LastSurveyDate = DateTime.Parse("2015-12-12")
                }
            };
            wells.ForEach(w => context.Wells.Add(w));
            context.SaveChanges();
            //end

            //Survey
            var surveys = new List<Survey>
            {
                new Survey
                {
                    WellID = "W001",
                    SurveyDesc = "blabla",
                    Type = "BUP",
                    Team = "A",
                    RequestBy = "Muhammad Fathir Irhas",
                    RequestDate = DateTime.Parse("2015-12-12"),
                    Comment = "......",
                    Status = "Completed",
                    Progress = "Completed",
                    ApprovedBy = "Johnny",
                    ApprovedDate = DateTime.Parse("2015-12-12"),
                    SubmitBy = "Tono",
                    SubmitDate = DateTime.Parse("2015-12-12"),
                    PICName = "Robby",
                    FileData = null

                },

                new Survey
                {
                    WellID = "W002",
                    SurveyDesc = "blabla",
                    Type = "BMP",
                    Team = "A",
                    RequestBy = "Muhammad Fathir Irhas",
                    RequestDate = DateTime.Parse("2015-12-12"),
                    Comment = "......",
                    Status = "Waiting For Approval",
                    Progress = "Waiting",
                    ApprovedBy = "Johnny",
                    ApprovedDate = DateTime.Parse("2015-12-12"),
                    SubmitBy = "Tono",
                    SubmitDate = DateTime.Parse("2015-12-12"),
                    PICName = "Robby",
                    FileData = null
                },

                new Survey
                {
                    WellID = "W003",
                    SurveyDesc = "blabla",
                    Type = "BUP",
                    Team = "C",
                    RequestBy = "Muhammad Fathir Irhas",
                    RequestDate = DateTime.Parse("2015-12-12"),
                    Comment = "......",
                    Status = "Completed",
                    Progress = "Completed",
                    ApprovedBy = "Johnny",
                    ApprovedDate = DateTime.Parse("2015-12-12"),
                    SubmitBy = "Tono",
                    SubmitDate = DateTime.Parse("2015-12-12"),
                    PICName = "Robby",
                    FileData = null
                }
            };
            surveys.ForEach(s => context.Surveys.Add(s));
            context.SaveChanges();
            //end

            
            //base.Seed(context);
        }
    }
}