using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importService_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Docstation context = new Docstation();
            int count = 0;
          foreach (patients_ patient in context.patients_)
            {
                
                string[] Fullname = patient.fullname.Split(' ');
                string login = patient.login;
                string password = patient.pwd;
                DateTime birthDate = UnixTimeStampToDateTime((double)patient.birthdate_timestamp);

                Country country;

                if (context.Countries.Where(x => x.Title == patient.country.Trim()).Any())
                {
                    country = context.Countries.Where(x => x.Title == patient.country.Trim()).FirstOrDefault();
                }
                else
                {
                    country = new Country { Title = patient.country };
                    context.Countries.Add(country);
                    context.SaveChangesAsync();
                    //context.SaveChanges();
                }
                



                Insurance insurance;

                if (context.Insurances.Where(x => x.Title == patient.insurance_name.Trim()).Any())
                {
                    insurance = context.Insurances.Where(x => x.Title == patient.insurance_name.Trim()).FirstOrDefault();
                }
                else
                {
                    insurance = new Insurance
                    {
                        Title = patient.insurance_name,
                        BIK = (int)patient.insurance_bik,
                        INN = (int)patient.insurance_inn,
                        Address = patient.insurance_address,
                        Country1 = country,
                        PP = (int)patient.insurance_p
                    };
                    context.Insurances.Add(insurance);
                    context.SaveChangesAsync();
                }

                Social_License social_License;

                if(context.Social_License.Where(x => x.Title == patient.social_type.Trim()).Any())
                {
                    social_License = context.Social_License.Where(x => x.Title == patient.social_type.Trim()).FirstOrDefault();
                }
                else
                {
                    social_License = new Social_License { Title = patient.social_type.Trim() };
                    context.Social_License.Add(social_License);
                    context.SaveChangesAsync();
                }

                Patient newPatient = new Patient
                {
                    Name = Fullname[0],
                    LastName = Fullname[1],
                    GuID = patient.guid,
                    Email = patient.email,
                    SocialSecNumber = (int)patient.social_sec_number,
                    EIN = patient.ein,
                    Phone = patient.phone,
                    Passport_Serial = (int)patient.passport_s,
                    Passport_Number = (int)patient.passport_n,
                    Insurance = insurance, 
                    BirthDate = birthDate, 
                    Social_License = social_License
                };
                context.Patients.Add(newPatient);
                context.SaveChangesAsync();
                count++;
                Console.WriteLine(count);

                //  Login_History login_History = new Login_History { IPaddress = patient.ipadress2, Patient = newPatient, Title = "LastLogin", //Browser = patient.uc  }


            }




            //Context context = new Context();
            //foreach (service_client_ scl in context.service_client_)
            //{
            //    Client client = context.Clients.Where(x => x.LastName == scl.Клиент.Trim()).FirstOrDefault();
            //    Service service = context.Services.Where(x => x.Title == scl.Услуга.Trim()).FirstOrDefault();


            //    Client_Service newScl = new Client_Service { Client = client, Service = service, StartDate = (DateTime)scl.Начало_оказания_услуги };

            //    context.Client_Service.Add(newScl);
            //}
            //context.SaveChanges();
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            if(unixTimeStamp < 0)
            {
                unixTimeStamp *= -1;
            }
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
          //    dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
