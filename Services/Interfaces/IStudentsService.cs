using efcore2.DTOs;
using efcore2.Model;

namespace efcore2.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        AddStudentResponse Create(AddStudentRequest createModel);
        bool Delete(int id);
        UpdateResponse Update(int id, UpdateRequest updateRequest);
    }
}