using ClinicDLLibrary;
using ClinicModelLibrary;
using System.Diagnostics;

namespace ClinicBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IData doctorsData;
        public DoctorService()
        {
            doctorsData = new Doctorsdata();
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = doctorsData.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
            //throw new NotImplementedException();
        }

        public Doctor Delete(int id)
        {
            var res=GetDoctor(id);
            if (res != null)
            {
                doctorsData.Delete(id);
                return res;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor GetDoctor(int id)
        {
            var doctor = doctorsData.GetById(id);
            return doctor == null ? throw new NoSuchDoctorException() : doctor;
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = doctorsData.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor UpdateDoctorExperience(int id, int experience)
        {
            var doctor = doctorsData.GetById(id);
            if (doctor != null)
            {
                if (doctor.Years_of_Experience > 0)
                {
                    doctor.Years_of_Experience = experience;
                    var result = doctorsData.Update(doctor);
                    return result;
                }
            }
            else
                Console.WriteLine("invalid choice"); ;
            
                
            
            //throw new NotImplementedException();
            throw new NoSuchDoctorException();
        }

        public Doctor UpdateDoctorPhone(int id, double phone)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Phone_no = phone;
                var result = doctorsData.Update(doctor);
                return result;
            }
            else
            {
                throw new InValidUpdateActionException();
            }
            throw new  NoSuchDoctorException();
            //throw new NotImplementedException();
        }
    }
}