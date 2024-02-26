

namespace Application.Features.Students.Queries.GetStudentPlatformData;
public class GetStudentPlatformDataResponse
{
    public Guid Id { get; set; }
    public string ImgUrl { get; set; }
    public UserPlatformDto User { get; set; }
    public List<ExamDto> StudentExams { get; set; } = new List<ExamDto>();
    public List<StudentAppealDto> StudentAppeals { get; set; } = new List<StudentAppealDto>();
    public List<SurveyDto> Surveys { get; set; } = new List<SurveyDto>();

}
