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
            int Patients = 0;
            int Countries = 0;
            int Insurances = 0;
            int License = 0;
            int UserType = 3;
            int Services = 0;
            int UUsers = 0;
            List<patients_> patients = context.patients_.ToList();
            AddUserType();
            AddServices();
            AddUsers();
            AddPatients();

            void AddUserType()
            {
                User_Type userType1 = new User_Type { Tittle = "Patient" };
                User_Type userType2 = new User_Type { Tittle = "Unknown2" };
                User_Type userType3 = new User_Type { Tittle = "Unknown3" };
                context.User_Type.Add(userType1);
                context.User_Type.Add(userType2);
                context.User_Type.Add(userType3);
                context.SaveChanges();
            }

            void AddServices()
            {
                List<services_> services = context.services_.ToList();
                foreach(services_ service in services)
                {
                    Service newService = new Service { Code = (int)service.Code, Price = Convert.ToDouble(service.Price), Tittle = service.Service };
                    context.Services.Add(newService);
                    context.SaveChanges();
                    Services++;
                }
            }

            void AddUsers()
            {
                List<users_> users = context.users_.ToList();
                foreach (users_ user in users)
                {
                    User_Type user_Type = context.User_Type.Where(x => x.ID == (int)(user.type - 1)).FirstOrDefault();
                    User newUser = new User { Login = user.login, Password = user.password, User_Type = user_Type };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    UUsers++;
                    string[] date = user.lastenter.Split('/');
                    int day = Int32.Parse(date[1]);
                    int month = Int32.Parse(date[0]);
                    int year = Int32.Parse(date[2]);

                    DateTime lastEnter = new DateTime(year, month, day);

                    Login_History newHistory = new Login_History { IPaddress = user.ip, User = newUser, LastEnter = lastEnter };
                    context.Login_History.Add(newHistory);

                    string[] services = user.services.Split(',');
                    List<int> codes = new List<int>();
                    foreach(string code in services)
                    {
                        codes.Add(Int32.Parse(code));
                    }

                    foreach(int code in codes)
                    {
                        User_Service newUserService = new User_Service { Service = context.Services.Where(x => x.Code == code).FirstOrDefault(), User = newUser };
                        context.User_Service.Add(newUserService);
                    }
                    
                }
            }

            void AddPatients()
            {
                foreach (patients_ patient in patients)
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
                        context.SaveChanges();
                        Countries++;
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
                        context.SaveChanges();
                        Insurances++;
                    }

                    Social_License social_License;

                    if (context.Social_License.Where(x => x.Title == patient.social_type.Trim()).Any())
                    {
                        social_License = context.Social_License.Where(x => x.Title == patient.social_type.Trim()).FirstOrDefault();
                    }
                    else
                    {
                        social_License = new Social_License { Title = patient.social_type.Trim() };
                        context.Social_License.Add(social_License);
                        context.SaveChanges();
                        License++;
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
                    context.SaveChanges();

                    User newUser = new User
                    {
                        Login = patient.login,
                        Password = patient.pwd,
                        Type = 0
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    User_Patient newUserPatient = new User_Patient
                    {
                        Patient = newPatient,
                        User = newUser
                    };
                    context.User_Patient.Add(newUserPatient);
                    context.SaveChanges();

                    Login_History login_History = new Login_History
                    {
                        User = newUser,
                        IPaddress = patient.ipadress2,
                        MetaData = patient.ua

                    };
                    context.Login_History.Add(login_History);
                    context.SaveChanges();

                    Patients++;
                    Console.WriteLine(Patients);

                }
                Console.WriteLine("Добавлено пациентов: " + Patients +
                          "\nСтран: " + Countries +
                          "\nСтраховок: " + Insurances +
                          "\nСоц. лицензий: " + License +
                          "\nТипов пользователей: " + UserType +
                          "\nСервисов: " + Services +
                          "\nПользователей: " + UUsers);
                Console.ReadKey();
            }
        }
          
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            if(unixTimeStamp < 0)
            {
                unixTimeStamp *= -1;
            }
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
