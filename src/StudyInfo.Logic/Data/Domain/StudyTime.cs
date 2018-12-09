namespace StudyInfo.Logic.Data.Domain
{
    public class StudyTime
    {
        public int SelfStudy { get; set; }
        public int Lecture { get; set; }
        public int SuperVisedIndependentWork { get; set; }
        public int Seminar { get; set; }

        public StudyTime(int superVisedIndependentWork, int lecture, int seminar, int selfStudy)
        {
            SelfStudy = selfStudy;
            Lecture = lecture;
            SuperVisedIndependentWork = superVisedIndependentWork;
            Seminar = seminar;
        }
    }
}
