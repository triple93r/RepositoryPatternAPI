using RepositoryPatternApi.Data;
using RepositoryPatternApi.Models;
using RepositoryPatternApi.Repositories.Interfaces;

namespace RepositoryPatternApi.Repositories.Implementations
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationDBContext _context;

        public PatientRepository(ApplicationDBContext db)
        {
            _context = db;
        }

        public int CreatePatient(Patient patient)
        {
            int result = -1;
            if (patient == null)
            {
                result = 0;
            }
            else
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                result = patient.Id;
            }
            return result;
        }

        public int DeletePatient(int id)
        {
            if(id == 0)
            {
                return -1;
            }
            var x = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
            if (x != null)
            {
                _context.Patients.Remove(x);
                _context.SaveChanges();
                return x.Id;
            }
            return 0;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            var y = _context.Patients.ToList();
            return y;
        }

        public Patient GetPatientById(int id)
        {
            var y = _context.Patients.Where(x => x.Id == id).FirstOrDefault() ?? null;
            return y;
        }

        public int UpdatePatient(Patient patient)
        {
            var y = _context.Patients.Where(x => x.Id == patient.Id).FirstOrDefault() ?? null;
            if (y != null)
            {
                y.Id = patient.Id;
                y.FirstName = patient.FirstName;
                y.LastName = patient.LastName;
                y.Adrress = patient.Adrress;
                y.Age = patient.Age;
                y.PatientType = patient.PatientType;
                y.bednum = patient.bednum;
                y.diagnosis = patient.diagnosis;
                _context.SaveChanges();
                return y.Id;
            }
            return -1;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
