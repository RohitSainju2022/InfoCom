using InfoCom.Model;
using InfoCom.Ui.Models.Models;

namespace InfoCom.Share.Mapper.CustomMapper
{
    public static class ScheduleCustomMapper
    {
        public static Schedule ToEntity(Schedule model, ScheduleModel self)
        {
            model.Title = self.Title;
            model.Description = self.Description;
            model.Status = self.Status;
            model.CreatedAt = DateTime.Now;
            return model;
        }

        public static ScheduleModel ToModel(Schedule self)
        {
            ScheduleModel model = new ScheduleModel();
            model.Id = self.Id;
            model.Title = self.Title;
            model.Description = self.Description;
            model.Status = self.Status;
            model.CreatedAt = self.CreatedAt;
            model.DueDate = self.DueDate;
            model.IsDeleted = self.IsDeleted;
            return model;
        }
    }
}
