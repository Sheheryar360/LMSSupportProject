using LMSSupportProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMSSupportProject.DataManager
{
    public class StudentLastActivityData
    {
        DBHelper lmsDB, vssDB;

        public StudentLastActivityData(IConfiguration configuration)
        {
            lmsDB = new DBHelper(configuration.GetConnectionString("lmsDB"));
            vssDB = new DBHelper(configuration.GetConnectionString("vssDB"));
        }
        public List<StudentLastActivityLog> GetStudentLastActivityData(string InstituteID, string UserEmail, int? NoOfDays, int? UserID)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@InstituteID", InstituteID },
                { "@NoOfDays", NoOfDays ?? 50 },
                { "@UserEmail", UserEmail ?? (object)DBNull.Value },
                { "@UserID", UserID ?? (object)DBNull.Value }
            };

            var dt = lmsDB.GetData("LVLQuery", parameters);

            if (dt == null || dt.Rows.Count <= 0)
                return null;

            return mapDataTableToStudentLastActivityLog(dt);
        }

        private List<StudentLastActivityLog> mapDataTableToStudentLastActivityLog(DataTable dt)
        {
            var listOfModel = new List<StudentLastActivityLog>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model = new StudentLastActivityLog();

                    model.LectureViewID = !Convert.IsDBNull(dt.Rows[0]["LectureViewID"]) ? Convert.ToInt32(dt.Rows[i]["LectureViewID"]) : null;
                    model.LectureID = !Convert.IsDBNull(dt.Rows[0]["LectureID"]) ? Convert.ToInt32(dt.Rows[i]["LectureID"]) : null;
                    model.LectureTitle = !Convert.IsDBNull(dt.Rows[0]["Lecture"]) ? dt.Rows[i]["Lecture"].ToString() : null;
                    model.VideoID = !Convert.IsDBNull(dt.Rows[0]["VideoID"]) ? dt.Rows[i]["VideoID"].ToString() : null;
                    model.Course = !Convert.IsDBNull(dt.Rows[0]["Course"]) ? dt.Rows[i]["Course"].ToString() : null;
                    model.Chapter = !Convert.IsDBNull(dt.Rows[0]["Chapter"]) ? dt.Rows[i]["Chapter"].ToString() : null;
                    model.Lecture = !Convert.IsDBNull(dt.Rows[0]["Lecture"]) ? dt.Rows[i]["Lecture"].ToString() : null;
                    model.LogAt = !Convert.IsDBNull(dt.Rows[0]["LogAt"]) ? Convert.ToDateTime(dt.Rows[i]["LogAt"]) : null;
                    model.DurationInMins = !Convert.IsDBNull(dt.Rows[0]["DurationInMins"]) ? Convert.ToDecimal(dt.Rows[i]["DurationInMins"]) : null;
                    model.ApproximateInternetSpeedRequiredInMbps = !Convert.IsDBNull(dt.Rows[0]["ApproximateInternetSpeedRequiredInMbps"]) ? Convert.ToDecimal(dt.Rows[i]["ApproximateInternetSpeedRequiredInMbps"]) : null;
                    model.SizeInMB = !Convert.IsDBNull(dt.Rows[0]["SizeInMB"]) ? Convert.ToDecimal(dt.Rows[i]["SizeInMB"]) : null;
                    model.EndDate = !Convert.IsDBNull(dt.Rows[0]["EndDate"]) ? Convert.ToDateTime(dt.Rows[i]["EndDate"]) : null;
                    model.StartDate = !Convert.IsDBNull(dt.Rows[0]["StartDate"]) ? Convert.ToDateTime(dt.Rows[i]["StartDate"]) : null;
                    model.LectureCreatedAt = !Convert.IsDBNull(dt.Rows[0]["LectureCreatedAt"]) ? Convert.ToDateTime(dt.Rows[i]["LectureCreatedAt"]) : null;

                    listOfModel.Add(model);
                }
            }

            return listOfModel;
        }

        public List<VideoModel> GetVideos(string VideoID)
        {

            var parameters = new Dictionary<string, object>()
            {
                { "@VideoID", VideoID ?? (object)DBNull.Value},
            };

            var dt = vssDB.GetData("GetVideoQuery", parameters);

            if (dt == null || dt.Rows.Count <= 0)
                return null;

            return MapDataTableToGetVideos(dt);
        }

        public List<VideoModel> MapDataTableToGetVideos(DataTable dt)
        {
            var listOfModel = new List<VideoModel>();

            if (dt != null && dt.Rows.Count > 0)
            {
                var model = new VideoModel();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.Video_ID = Convert.ToInt32(dt.Rows[0]["Video_ID"]);
                    model.Video_FileName = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[0]["Video_FileName"].ToString() : null;
                    model.Video_FilePath = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[0]["Video_FilePath"].ToString() : null;
                    model.Video_Status = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[0]["Video_Status"].ToString() : null;
                    model.Video_AccountID = dt.Rows[0]["Video_AccountID"].ToString();
                    model.Video_Duration = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? Convert.ToDecimal(dt.Rows[0]["Video_Duration"]) : null;
                    model.Video_FileSize = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? Convert.ToDecimal(dt.Rows[0]["Video_FileSize"]) : null;
                    model.Video_MediaFilesPath = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[0]["Video_MediaFilesPath"].ToString() : null;
                    model.Video_SourceFileURL = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[0]["Video_SourceFileURL"].ToString() : null;
                    model.Video_StatusNotificationURL = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[0]["Video_StatusNotificationURL"].ToString() : null;
                    model.Video_CreatedAt = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? Convert.ToDateTime(dt.Rows[0]["Video_CreatedAt"]) : null;
                    model.Video_EncodingStartedAt = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? Convert.ToDateTime(dt.Rows[0]["Video_EncodingStartedAt"]) : null;
                    model.Video_EncodingEndedAt = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? Convert.ToDateTime(dt.Rows[0]["Video_EncodingEndedAt"]) : null;

                    listOfModel.Add(model);
                }
            }
            return listOfModel;
        }

        public List<UserInfo> GetUserInfo(string InstituteID, string UserEmail)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@InstituteID", InstituteID ?? (object)DBNull.Value},
                { "@UserEmail", UserEmail ?? (object)DBNull.Value},
            };

            var dt = lmsDB.GetData("UserInfoQuery", parameters);

            if (dt == null || dt.Rows.Count <= 0)
                return null;

            return MapDataTableToUserInfo(dt);
        }

        private List<UserInfo> MapDataTableToUserInfo(DataTable dt)
        {
            var lisofmodel = new List<UserInfo>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model = new UserInfo();

                    model.ID = Convert.ToInt32(dt.Rows[i]["UserID"]);
                    model.Email = !Convert.IsDBNull(dt.Rows[i]["UserEmail"]) ? dt.Rows[i]["UserEmail"].ToString() : null;
                    model.FirstName = !Convert.IsDBNull(dt.Rows[i]["FirstName"]) ? dt.Rows[i]["FirstName"].ToString() : null;
                    model.LastName = !Convert.IsDBNull(dt.Rows[i]["LastName"]) ? dt.Rows[i]["LastName"].ToString() : null;

                    lisofmodel.Add(model);
                }
            }
            return lisofmodel;
        }

        public List<UserDeviceInfo> GetUserDeviceInfo(int? UserID)
        {

            var parameters = new Dictionary<string, object>()
            {
                { "@UserID", UserID ?? (object)DBNull.Value},
            };

            var dt = lmsDB.GetData("UserDeviceInfoQuery", parameters);

            if (dt == null || dt.Rows.Count <= 0)
                return null;

            return MapDataTableToGetUserDeviceInfo(dt);
        }

        private List<UserDeviceInfo> MapDataTableToGetUserDeviceInfo(DataTable dt)
        {
            var listOfModel = new List<UserDeviceInfo>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model = new UserDeviceInfo();
                    model.UserID = !Convert.IsDBNull(dt.Rows[i]["userID"]) ? Convert.ToInt32(dt.Rows[i]["userID"]) : null;
                    model.DeviceID = !Convert.IsDBNull(dt.Rows[i]["DeviceID"]) ? dt.Rows[i]["DeviceID"].ToString() : null;
                    model.DeviceInfo = !Convert.IsDBNull(dt.Rows[i]["DeviceInfo"]) ? dt.Rows[i]["DeviceInfo"].ToString() : null;
                    model.Status = !Convert.IsDBNull(dt.Rows[i]["DeviceStatus"]) ? Convert.ToInt32(dt.Rows[i]["DeviceStatus"]) : null;
                    model.CreatedAt = !Convert.IsDBNull(dt.Rows[i]["CreatedAt"]) ? Convert.ToDateTime(dt.Rows[i]["CreatedAt"]) : null;
                    model.UpdatedAt = !Convert.IsDBNull(dt.Rows[i]["UpdatedAt"]) ? Convert.ToDateTime(dt.Rows[i]["UpdatedAt"]) : null;

                    listOfModel.Add(model);
                }
            }
            return listOfModel;
        }

        public List<Lecture> GetLectureDetails(string InstituteID, int? LectureID, string? LectureTitle, int? ChapterID, int? PaperID)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@InstituteID", InstituteID ?? (object)DBNull.Value},
                { "@LectureID", LectureID ?? (object)DBNull.Value},
                { "@LectureTitle", LectureTitle ?? (object)DBNull.Value},
                { "@ChapterID", ChapterID ?? (object)DBNull.Value},
                { "@PaperID", PaperID ?? (object)DBNull.Value},
            };

            var lecturesDt = lmsDB.GetData("LectureDetailsQuery", parameters);

            if (lecturesDt == null || lecturesDt.Rows.Count <= 0)
                return null;


            string[] videoIDs = lecturesDt.AsEnumerable().Select(x => x.Field<string>("VideoID").ToString()).ToArray();


            var videosDt = vssDB.GetData("GetVideos", new Dictionary<string, object>() { { "IDs", string.Join(",", videoIDs) } });

            return MapDataTableToGetLecture(lecturesDt, videosDt);
        }

        private List<LectureDetails> MapDataTableToGetLectureDetails(DataTable dt)
        {
            var listOfModel = new List<LectureDetails>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    var model = new LectureDetails();
                    model.LectureModels = new LectureModel
                    {
                        Lecture_ID = Convert.ToInt32(dt.Rows[i]["LectureID"]),
                        Lecture_Title = !Convert.IsDBNull(dt.Rows[i]["LectureTitle"]) ? dt.Rows[i]["LectureTitle"].ToString() : null,
                        Lecture_Status = !Convert.IsDBNull(dt.Rows[i]["LectureStatus"]) ? Convert.ToInt32(dt.Rows[i]["LectureStatus"]) : null,
                        DurationInMins = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDecimal(dt.Rows[i]["DurationInMins"]) : null,
                        SizeInMB = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDecimal(dt.Rows[i]["SizeInMB"]) : null,
                        MBsPerMinute = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDecimal(dt.Rows[i]["MBsPerMinute"]) : null,
                        ApproximateInternetSpeedRequiredInMbps = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDecimal(dt.Rows[i]["ApproximateInternetSpeedRequiredInMbps"]) : null,
                        Lecture_StartDate = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDateTime(dt.Rows[i]["StartDate"]) : null,
                        Lecture_EndDate = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDateTime(dt.Rows[i]["EndDate"]) : null,
                        Lecture_CreatedAt = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDateTime(dt.Rows[i]["CreatedAt"]) : null,
                        Lecture_CreatedBy = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["CreatedBy"].ToString() : null,
                        Lecture_UpdatedAt = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToDateTime(dt.Rows[i]["UpdatedAt"]) : null,
                        Lecture_UpdatedBy = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["UpdatedBy"].ToString() : null,
                        Lecture_Deleted = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToInt32(dt.Rows[i]["LectureDeleted"]) : null
                    };

                    model.QualificationModels = new QualificationModel
                    {
                        Qualification_ID = Convert.ToInt32(dt.Rows[i]["QualificationID"]),
                        QualificationTitle = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["QualificationTitle"].ToString() : null,
                        Qualification_Deleted = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToInt32(dt.Rows[i]["QualificationDeleted"]) : null
                    };

                    model.PaperModels = new PaperModel
                    {
                        Paper_ID = Convert.ToInt32(dt.Rows[i]["PaperID"]),
                        Paper_Title = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["PaperTitle"].ToString() : null,
                        Paper_Deleted = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToInt32(dt.Rows[i]["PaperDeleted"]) : null
                    };
                    model.ChapterModels = new ChapterModel
                    {
                        Chapter_ID = Convert.ToInt32(dt.Rows[i]["ChapterID"]),
                        Chapter_Title = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["ChapterTitle"].ToString() : null,
                        Chapter_Deleted = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToInt32(dt.Rows[i]["ChapterDeleted"]) : null
                    };
                    model.CourceModels = new CourseModel
                    {
                        Cource_ID = Convert.ToInt32(dt.Rows[i]["CourseID"]),
                        Cource_Title = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["CourseTitle"].ToString() : null,
                        Cource_Deleted = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? Convert.ToInt32(dt.Rows[i]["CourseDeleted"]) : null
                    };
                    model.Video_ID = !Convert.IsDBNull(dt.Rows[i]["VideoID"]) ? dt.Rows[i]["VideoID"].ToString() : null;
                    model.CreatedByEmail = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["CreatedByEmail"].ToString() : null;
                    model.CreatedByName = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["CreatedByName"].ToString() : null;
                    model.UpdatedByEmail = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["UpdatedByEmail"].ToString() : null;
                    model.UpdatedByName = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["UpdatedByName"].ToString() : null;
                    model.Trainer = !Convert.IsDBNull(dt.Rows[i]["LectureID"]) ? dt.Rows[i]["Trainer"].ToString() : null;
                    model.VideoModels = GetVideos(model.Video_ID);

                    listOfModel.Add(model);
                }
            }
            return listOfModel;
        }

        private List<Lecture> MapDataTableToGetLecture(DataTable lecturesDt, DataTable videosDt)
        {
            var lectures = new List<Lecture>();

            if (lecturesDt != null && lecturesDt.Rows.Count > 0)
            {
                for (int i = 0; i < lecturesDt.Rows.Count; i++)
                {
                    var model = new Lecture()
                    {

                        id = Convert.ToInt32(lecturesDt.Rows[i]["LectureID"]),
                        title = !Convert.IsDBNull(lecturesDt.Rows[i]["LectureTitle"]) ? lecturesDt.Rows[i]["LectureTitle"].ToString() : null,
                        status = !Convert.IsDBNull(lecturesDt.Rows[i]["LectureStatus"]) ? Convert.ToInt32(lecturesDt.Rows[i]["LectureStatus"]) : null,
                        durationInMins = !Convert.IsDBNull(lecturesDt.Rows[i]["DurationInMins"]) ? Convert.ToDecimal(lecturesDt.Rows[i]["DurationInMins"]) : null,
                        sizeInMB = !Convert.IsDBNull(lecturesDt.Rows[i]["SizeInMB"]) ? Convert.ToDecimal(lecturesDt.Rows[i]["SizeInMB"]) : null,
                        MBsPerMinute = !Convert.IsDBNull(lecturesDt.Rows[i]["MBsPerMinute"]) ? Convert.ToDecimal(lecturesDt.Rows[i]["MBsPerMinute"]) : null,
                        approximateInternetSpeedRequiredInMbps = !Convert.IsDBNull(lecturesDt.Rows[i]["ApproximateInternetSpeedRequiredInMbps"]) ? Convert.ToDecimal(lecturesDt.Rows[i]["ApproximateInternetSpeedRequiredInMbps"]) : null,
                        startDate = !Convert.IsDBNull(lecturesDt.Rows[i]["StartDate"]) ? Convert.ToDateTime(lecturesDt.Rows[i]["StartDate"]) : null,
                        endDate = !Convert.IsDBNull(lecturesDt.Rows[i]["EndDate"]) ? Convert.ToDateTime(lecturesDt.Rows[i]["EndDate"]) : null,
                        createdAt = !Convert.IsDBNull(lecturesDt.Rows[i]["CreatedAt"]) ? Convert.ToDateTime(lecturesDt.Rows[i]["CreatedAt"]) : DateTime.MinValue,
                        createdBy = !Convert.IsDBNull(lecturesDt.Rows[i]["CreatedBy"]) ? lecturesDt.Rows[i]["CreatedBy"].ToString() : null,
                        updatedAt = !Convert.IsDBNull(lecturesDt.Rows[i]["UpdatedAt"]) ? Convert.ToDateTime(lecturesDt.Rows[i]["UpdatedAt"]) : null,
                        updatedBy = !Convert.IsDBNull(lecturesDt.Rows[i]["UpdatedBy"]) ? lecturesDt.Rows[i]["UpdatedBy"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(lecturesDt.Rows[i]["LectureDeleted"]) ? Convert.ToInt32(lecturesDt.Rows[i]["LectureDeleted"]) : 1,
                        createdByEmail = !Convert.IsDBNull(lecturesDt.Rows[i]["CreatedByEmail"]) ? lecturesDt.Rows[i]["CreatedByEmail"].ToString() : null,
                        createdByName = !Convert.IsDBNull(lecturesDt.Rows[i]["CreatedByName"]) ? lecturesDt.Rows[i]["CreatedByName"].ToString() : null,
                        updatedByEmail = !Convert.IsDBNull(lecturesDt.Rows[i]["UpdatedByEmail"]) ? lecturesDt.Rows[i]["UpdatedByEmail"].ToString() : null,
                        updatedByName = !Convert.IsDBNull(lecturesDt.Rows[i]["UpdatedByName"]) ? lecturesDt.Rows[i]["UpdatedByName"].ToString() : null,
                        
                    };

                    if (!Convert.IsDBNull(lecturesDt.Rows[i]["VideoID"]) && videosDt.Rows.Count > 0)
                    {
                        var videoRow = videosDt.Select($"[ID] = '{lecturesDt.Rows[i]["VideoID"]}'")?[0];

                        model.video = new Video()
                        {
                            id = !Convert.IsDBNull(videoRow["ID"]) ? videoRow["ID"].ToString() : null,
                            status = !Convert.IsDBNull(videoRow["Status"]) ? videoRow["Status"].ToString() : null,
                            encodingStartedAt = !Convert.IsDBNull(videoRow["EncodingStartedAt"]) ? Convert.ToDateTime(videoRow["EncodingStartedAt"]) : null,
                            encodingEndedAt = !Convert.IsDBNull(videoRow["EncodingEndedAt"]) ? Convert.ToDateTime(videoRow["EncodingEndedAt"]) : null
                        };
                    } else {
                        model.video = new Video()
                        {
                            id = lecturesDt.Rows[i]["VideoID"].ToString()
                        };
                    }

                    model.qualification = new Qualification()
                    {
                        id = Convert.ToInt32(lecturesDt.Rows[i]["QualificationID"]),
                        title = !Convert.IsDBNull(lecturesDt.Rows[i]["QualificationTitle"]) ? lecturesDt.Rows[i]["QualificationTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(lecturesDt.Rows[i]["QualificationDeleted"]) ? Convert.ToInt32(lecturesDt.Rows[i]["QualificationDeleted"]) : 1
                    };

                    model.course = new Course()
                    {
                        id = Convert.ToInt32(lecturesDt.Rows[i]["CourseID"]),
                        title = !Convert.IsDBNull(lecturesDt.Rows[i]["CourseTitle"]) ? lecturesDt.Rows[i]["CourseTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(lecturesDt.Rows[i]["CourseDeleted"]) ? Convert.ToInt32(lecturesDt.Rows[i]["CourseDeleted"]) : 1
                    };

                    model.paper = new Paper()
                    {
                        id = Convert.ToInt32(lecturesDt.Rows[i]["PaperID"]),
                        title = !Convert.IsDBNull(lecturesDt.Rows[i]["PaperTitle"]) ? lecturesDt.Rows[i]["PaperTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(lecturesDt.Rows[i]["PaperDeleted"]) ? Convert.ToInt32(lecturesDt.Rows[i]["PaperDeleted"]) : 1,
                        trainer = !Convert.IsDBNull(lecturesDt.Rows[i]["Trainer"]) ? lecturesDt.Rows[i]["Trainer"].ToString() : null
                    };

                    model.chapter = new Chapter()
                    {
                        id = Convert.ToInt32(lecturesDt.Rows[i]["ChapterID"]),
                        title = !Convert.IsDBNull(lecturesDt.Rows[i]["ChapterTitle"]) ? lecturesDt.Rows[i]["ChapterTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(lecturesDt.Rows[i]["ChapterDeleted"]) ? Convert.ToInt32(lecturesDt.Rows[i]["ChapterDeleted"]) : 1
                    };

                    lectures.Add(model);
                }
            }
            return lectures;
        }

        public List<Handout> GetHandoutDetails(string InstituteID, int? ChapterID, int? PaperID, string? Name)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@InstituteID", InstituteID ?? (object)DBNull.Value},
                { "@ChapterID", ChapterID ?? (object)DBNull.Value},
                { "@PaperID", PaperID ?? (object)DBNull.Value},
                { "@FileTitle", Name ?? (object)DBNull.Value},
            };

            var dt = lmsDB.GetData("HandoutQuery", parameters);

            if (dt == null || dt.Rows.Count <= 0)
                return null;

            return MapDataTableToGetHandouts(dt);
        }

        private List<Handout> MapDataTableToGetHandouts(DataTable dt)
        {
            var handouts = new List<Handout>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var handout = new Handout()
                    {
                        id = Convert.ToInt32(dt.Rows[i]["FileID"]),
                        title = Convert.IsDBNull(dt.Rows[i]["FileName"]) ? null : dt.Rows[i]["FileName"].ToString(),
                        path = Convert.IsDBNull(dt.Rows[i]["FilePath"]) ? null : dt.Rows[i]["FilePath"].ToString(),
                        sequence = Convert.IsDBNull(dt.Rows[i]["FileSequence"]) ? null : Convert.ToInt32(dt.Rows[i]["FileSequence"]),
                        fileType = Convert.IsDBNull(dt.Rows[i]["FileType"]) ? null : dt.Rows[i]["FileType"].ToString(),
                        status = Convert.IsDBNull(dt.Rows[i]["FileStatus"]) ? null : Convert.ToInt32(dt.Rows[i]["FileStatus"]),
                        createdAt = Convert.IsDBNull(dt.Rows[i]["FileCreatedAt"]) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["FileCreatedAt"]),
                        createdBy = Convert.IsDBNull(dt.Rows[i]["FileCreatedBy"]) ? null : dt.Rows[i]["FileCreatedBy"].ToString(),
                        updatedAt = Convert.IsDBNull(dt.Rows[i]["FileUpdatedAt"]) ? null : Convert.ToDateTime(dt.Rows[i]["FileUpdatedAt"]),
                        updatedBy = Convert.IsDBNull(dt.Rows[i]["FileUpdatedBy"]) ? null : dt.Rows[i]["FileUpdatedBy"].ToString(),
                        isDeleted = Convert.IsDBNull(dt.Rows[i]["FileDeleted"]) ? 1 : Convert.ToInt32(dt.Rows[i]["FileDeleted"])
                    };

                    handout.qualification = new Qualification()
                    {
                        id = Convert.ToInt32(dt.Rows[i]["QualificationID"]),
                        title = !Convert.IsDBNull(dt.Rows[i]["QualificationTitle"]) ? dt.Rows[i]["QualificationTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(dt.Rows[i]["QualificationDeleted"]) ? Convert.ToInt32(dt.Rows[i]["QualificationDeleted"]) : 1
                    };

                    handout.course = new Course()
                    {
                        id = Convert.ToInt32(dt.Rows[i]["CourseID"]),
                        title = !Convert.IsDBNull(dt.Rows[i]["CourseTitle"]) ? dt.Rows[i]["CourseTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(dt.Rows[i]["CourseDeleted"]) ? Convert.ToInt32(dt.Rows[i]["CourseDeleted"]) : 1
                    };

                    handout.paper = new Paper()
                    {
                        id = Convert.ToInt32(dt.Rows[i]["PaperID"]),
                        title = !Convert.IsDBNull(dt.Rows[i]["PaperTitle"]) ? dt.Rows[i]["PaperTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(dt.Rows[i]["PaperDeleted"]) ? Convert.ToInt32(dt.Rows[i]["PaperDeleted"]) : 1,
                        trainer = !Convert.IsDBNull(dt.Rows[i]["Trainer"]) ? dt.Rows[i]["Trainer"].ToString() : null
                    };

                    handout.chapter = new Chapter()
                    {
                        id = Convert.ToInt32(dt.Rows[i]["ChapterID"]),
                        title = !Convert.IsDBNull(dt.Rows[i]["ChapterTitle"]) ? dt.Rows[i]["ChapterTitle"].ToString() : null,
                        isDeleted = !Convert.IsDBNull(dt.Rows[i]["ChapterDeleted"]) ? Convert.ToInt32(dt.Rows[i]["ChapterDeleted"]) : 1
                    };

                    handouts.Add(handout);
                }
            }
            return handouts;
        }

        private List<HandoutDetails> MapDataTableToGetHandoutDetails(DataTable dt)
        {
            var listOfModel = new List<HandoutDetails>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model = new HandoutDetails();
                    model.FileID = Convert.ToInt32(dt.Rows[i]["FileID"]);
                    model.FileName = dt.Rows[i]["FileName"].ToString();
                    model.FilePath = dt.Rows[i]["FilePath"].ToString();
                    model.FileSequence = Convert.ToInt32(dt.Rows[i]["FileSequence"]);
                    model.FileType = dt.Rows[i]["FileType"].ToString();
                    model.FileStatus = Convert.ToInt32(dt.Rows[i]["FileStatus"]);
                    model.FileCreatedAt = Convert.ToDateTime(dt.Rows[i]["FileCreatedAt"]);
                    model.FileCreatedBy = new CreatedBy
                    {
                        Id = !Convert.IsDBNull(dt.Rows[i]["FileCreatedBy"]) ? Convert.ToInt32(dt.Rows[i]["FileCreatedBy"]) : null,
                        FullName = !Convert.IsDBNull(dt.Rows[i]["FullName"]) ? dt.Rows[i]["FullName"].ToString() : null
                    };
                    model.FileUpdatedBy = !Convert.IsDBNull(dt.Rows[i]["FileUpdatedBy"]) ? Convert.ToInt32(dt.Rows[i]["FileUpdatedBy"]) : null;
                    model.FileUpdatedAt = !Convert.IsDBNull(dt.Rows[i]["FileUpdatedAt"]) ? Convert.ToDateTime(dt.Rows[i]["FileUpdatedAt"]) : null;
                    model.ChapterID = !Convert.IsDBNull(dt.Rows[i]["ChapterID"]) ? Convert.ToInt32(dt.Rows[i]["ChapterID"]) : null;
                    model.ChapterTitle = !Convert.IsDBNull(dt.Rows[i]["ChapterTitle"]) ? dt.Rows[i]["ChapterTitle"].ToString() : null;
                    model.PaperID = !Convert.IsDBNull(dt.Rows[i]["PaperID"]) ? Convert.ToInt32(dt.Rows[i]["PaperID"]) : null;
                    model.PaperTitle = !Convert.IsDBNull(dt.Rows[i]["PaperTitle"]) ? dt.Rows[i]["PaperTitle"].ToString() : null;
                    model.Trainer = !Convert.IsDBNull(dt.Rows[i]["Trainer"]) ? dt.Rows[i]["Trainer"].ToString() : null;
                    model.CourseID = !Convert.IsDBNull(dt.Rows[i]["CourseID"]) ? Convert.ToInt32(dt.Rows[i]["CourseID"]) : null;
                    model.CourseTitle = !Convert.IsDBNull(dt.Rows[i]["CourseTitle"]) ? dt.Rows[i]["CourseTitle"].ToString() : null;
                    model.QualificationID = !Convert.IsDBNull(dt.Rows[i]["QualificationID"]) ? Convert.ToInt32(dt.Rows[i]["QualificationID"]) : null;
                    model.QualificationTitle = !Convert.IsDBNull(dt.Rows[i]["QualificationTitle"]) ? dt.Rows[i]["QualificationTitle"].ToString() : null;
                    model.FileDeleted = Convert.ToInt32(dt.Rows[i]["FileDeleted"]);
                    model.ChapterDeleted = Convert.ToInt32(dt.Rows[i]["ChapterDeleted"]);
                    model.PaperDeleted = Convert.ToInt32(dt.Rows[i]["PaperDeleted"]);
                    model.CourseDeleted = Convert.ToInt32(dt.Rows[i]["CourseDeleted"]);
                    model.QualificationDeleted = Convert.ToInt32(dt.Rows[i]["QualificationDeleted"]);

                    listOfModel.Add(model);
                }
            }
            return listOfModel;
        }
    }
}

