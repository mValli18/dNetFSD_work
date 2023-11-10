using ClinicBLLibrary;
using ClinicModelLibrary;

namespace ClinicApp
{
    public class Program
    {
        IDoctorService doctorService;

        public Program()
        {
            doctorService= new DoctorService();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Update Doctor Phone");
            Console.WriteLine("3. Update Doctor Exprience");
            Console.WriteLine("4. Delete Doctor"); ;
            Console.WriteLine("5. Print all doctor details");
            Console.WriteLine("0. Exit");
        }
        void AdminFunctions()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        UpdatePhone();
                        break;
                    case 3:
                        UpdateExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        PrintAllDoctorDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;

                }
            }while(choice!=0);
        }
        void AddDoctor()
        {
            try
            {
                Doctor doctor = new Doctor();
                doctor = TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Please enter the Doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the phone number");
            doctor.Phone_no = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the Specilization");
            doctor.Specilisation= Console.ReadLine();
            Console.WriteLine("Please enter the Years of Exprience");
            doctor.Years_of_Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Consultation Fee");
            doctor.Consultation_fee = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please upload the Lisence Path");
            doctor.Lisence = Console.ReadLine();
            return doctor;
  
        }
            private void PrintAllDoctorDetails()
        {
            Console.WriteLine("***********************************");
            var doctors = doctorService.GetDoctors();
            foreach (var doc in doctors)
            {
                Console.WriteLine(doc);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }

        int GetDoctorId()
        {
            int id;
            Console.WriteLine("Please enter the your id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorId();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor Details deleted");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdatePhone()
        {
            var id = GetDoctorId();
            Console.WriteLine("Please enter the new phone number");
            double phone_no = Convert.ToSingle(Console.ReadLine());
            Doctor doctor = new Doctor();
            //doctor.Phone_no = phone_no;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorPhone(id, phone_no);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateExperience()
        {
            var id = GetDoctorId();
            Console.WriteLine("Please enter the Years_of_Exprience to be updated");
            int experience=Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            //doctor.Years_of_Experience = experience;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorExperience(id, experience);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Program p= new Program();
            //p.DisplayAdminMenu();
            p.AdminFunctions();
        }
    }
}