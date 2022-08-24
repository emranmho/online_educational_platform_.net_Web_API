using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CoursServices
    {
        //////public static List<CoursModel> CourseList()
        //////{
        //////    var data = DataAccessFactory.GetCoursDataAccess().Get();
        //////    var sdata = new List<CoursModel>();
        //////    foreach (var item in data)
        //////    {
        //////        sdata.Add(new CoursModel()
        //////        {
        //////            Id = item.Id,
        //////            Name = item.Name,
        //////            Description = item.Description,
        //////            Capacity = item.Capacity,
        //////            Cost = item.Cost,
        //////            Enroll = item.Enroll,
        //////            Status = item.Status,
        //////            Teacher_Id = item.Teacher_Id,
        //////        });
        //////    }
        //////    return sdata;
        //////}
        //////public static List<CoursModel> MyCourseList(int id)
        //////{
        //////    var data = DataAccessFactory.GetCoursDataAccess().Get().Where(c => c.Teacher_Id == id && c.Status == 1);
        //////    var sdata = new List<CoursModel>();
        //////    foreach (var item in data)
        //////    {
        //////        sdata.Add(new CoursModel()
        //////        {
        //////            Id = item.Id,
        //////            Name = item.Name,
        //////            Description = item.Description,
        //////            Capacity = item.Capacity,
        //////            Cost = item.Cost,
        //////            Enroll = item.Enroll,
        //////            Status = item.Status,
        //////            Teacher_Id = item.Teacher_Id,
        //////        });
        //////    }
        //////    return sdata;
        //////}
        //////public static List<CoursModel> PendingCoursList(int id)
        //////{
        //////    var data = DataAccessFactory.GetCoursDataAccess().Get().Where(c => c.Teacher_Id == id && c.Status == 0);
        //////    var sdata = new List<CoursModel>();
        //////    foreach (var item in data)
        //////    {
        //////        sdata.Add(new CoursModel()
        //////        {
        //////            Id = item.Id,
        //////            Name = item.Name,
        //////            Description = item.Description,
        //////            Capacity = item.Capacity,
        //////            Cost = item.Cost,
        //////            Enroll = item.Enroll,
        //////            Status = item.Status,
        //////            Teacher_Id = item.Teacher_Id,
        //////        });
        //////    }
        //////    return sdata;
        //////}

        //////public static bool AddCours(CoursModel obj, int id,int st)
        //////{
        //////    var c = new Cours()
        //////    {
        //////        Id = obj.Id,
        //////        Name = obj.Name,
        //////        Description = obj.Description,
        //////        Capacity = obj.Capacity,
        //////        Cost = obj.Cost,
        //////        Enroll = 0,
        //////        Status = st,
        //////        Teacher_Id = id
        //////    };
        //////    return DataAccessFactory.GetCoursDataAccess().Create(c);
        //////}

        //////public static bool UpdateCours(Cours obj)
        //////{
        //////    var data = DataAccessFactory.GetCoursDataAccess().Get(obj.Id);

        //////    data.Id = obj.Id;
        //////    data.Name = obj.Name;
        //////    data.Description = obj.Description;
        //////    data.Status = obj.Status;
        //////    data.Capacity = obj.Capacity;
        //////    data.Enroll = obj.Enroll;
        //////    return DataAccessFactory.GetCoursDataAccess().Update(data);
        //////}
        //////public static bool DeleteCours(int id)
        //////{
        //////    return DataAccessFactory.GetCoursDataAccess().Delete(id);
        //////}
    }
}
