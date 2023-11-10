namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Phone_no { get; set; }
        public string Specilisation { get; set; } = string.Empty;
        public int Years_of_Experience { get; set; }
        public float Consultation_fee { get; set; }
        public string Lisence { get; set; }
        public Doctor()
        {

        }
        public Doctor(int id, string name, double phone_no, string specilisation, int experience, float fee, string lisence)
        {
            Id = id;
            Name = name;
            Phone_no = phone_no;
            Specilisation = specilisation;
            Years_of_Experience = experience;
            Consultation_fee = fee;
            Lisence = lisence;
        }
        public override string ToString()
        {
            return $"Doctor Id : {Id}\nDoctor Name : {Name}\nPhone_no : Rs. {Phone_no}\nSpecilization : {Specilisation}" +
                $"\nYears_of_Experience : {Years_of_Experience}%\nConsultation_fee : {Consultation_fee}";



        }
    }
}