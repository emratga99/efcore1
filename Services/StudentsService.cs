using efcore2.DTOs;
using efcore2.Model;
using efcore2.Repositories;
using System.Linq.Expressions;

namespace efcore2.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public AddStudentResponse Create(AddStudentRequest createModel)
        {
            var createStudent = new Student
            {
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                City = createModel.City,
                State = createModel.State
            };

            var student = _studentRepository.Create(createStudent);

            _studentRepository.SaveChanges();

            return new AddStudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State
            };
        }

        public IEnumerable<Student> GetAll()
        {
            var viewModels = _studentRepository.GetAll(g => true)
                .Select(student => new Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    City = student.City,
                    State = student.State
                });

            return viewModels;
        }

        public AddStudentResponse? Get(Expression<Func<AddStudentResponse, bool>> predicate, int id)
        {
            var student = _studentRepository.Get(g => g.Id == id);

            if (student == null) return null;

            var viewModels = new AddStudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State
            };

            return viewModels;
        }

        public UpdateResponse Update(int id, UpdateRequest updateModel)
        {
            var student = _studentRepository.Get(x => x.Id == id);

            if (student == null) return null;

            student.FirstName = updateModel.FirstName;
            student.LastName = updateModel.LastName;
            student.City = updateModel.City;
            student.State = updateModel.State;

            student = _studentRepository.Update(student);

            if (student == null) return null;

            var viewModel = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State
            };

            _studentRepository.SaveChanges();

            return new UpdateResponse
            {
                FirstName = updateModel.FirstName,
                LastName = updateModel.LastName,
                City = updateModel.City,
                State = updateModel.State
            };
        }

        public bool Delete(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id);

            if (student != null)
            {
                _studentRepository.Delete(student);
                _studentRepository.SaveChanges();
            }

            return true;
        }
    }
}