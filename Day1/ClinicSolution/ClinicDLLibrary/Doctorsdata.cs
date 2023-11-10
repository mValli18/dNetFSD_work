using ClinicModelLibrary;
using System.Net.Http.Headers;

namespace ClinicDLLibrary
{
    public class Doctorsdata : IData
    {
        Dictionary<int,Doctor>doctors= new Dictionary<int,Doctor>();
        public Doctor Add(Doctor doctor)
        {
            int id = GenerateId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Doctor already Exists");
                Console.WriteLine(ex.Message);
            }
            return null;
            throw new NotImplementedException();
        }

        public Doctor Delete(int id)
        {
            var res= doctors[id];
            doctors.Remove(id);
            return res;
            throw new NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            if(doctors.Count != 0)
                return doctors.Values.ToList();
            return null;
            throw new NotImplementedException();
        }

        public Doctor GetById(int id)
        {
            if(doctors.ContainsKey(id))
                return doctors[id];
            return null;

            throw new NotImplementedException();
        }

        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctor;
            throw new NotImplementedException();
        }
        public int GenerateId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }
    }
}