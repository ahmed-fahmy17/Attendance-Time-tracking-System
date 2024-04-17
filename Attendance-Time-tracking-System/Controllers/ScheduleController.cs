﻿using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    public class ScheduleController : Controller
    {
        IScheduleRepository scheduleRepository;
        public ScheduleController(IScheduleRepository _scheduleRepository)
        {
            scheduleRepository = _scheduleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowSchedules()
        {
            int InstructorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View(scheduleRepository.GetSchedules(InstructorId));
        }
        public IActionResult GetAllSchedules()
        {
            int InstructorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Schedule> Schedules = scheduleRepository.GetSchedules(InstructorId);
            return PartialView("ViewScheduleTablePartialView", Schedules);
        }
        public IActionResult GetCurrentWeekSchedules()
        {
            int InstructorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            DateOnly StartDate = GetStartDateOfCurrentWeek();
            DateOnly EndDate = StartDate;
            EndDate.AddDays(6);
            List<Schedule> Schedules = scheduleRepository.GetSchedules(InstructorId,StartDate,EndDate);
            return PartialView("ViewScheduleTablePartialView", Schedules);
        }
        public IActionResult GetNextWeekSchedules()
        {
            int InstructorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            DateOnly StartDate = GetStartDateOfCurrentWeek().AddDays(7);
            DateOnly EndDate = StartDate;
            EndDate = EndDate.AddDays(6);
            List<Schedule> Schedules = scheduleRepository.GetSchedules(InstructorId, StartDate, EndDate);
            return PartialView("ViewScheduleTablePartialView", Schedules);
        }
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Schedule schedule)
        {
            if(ModelState.IsValid)
            {
                int InstructorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                scheduleRepository.AddSchedule(InstructorId, schedule);
                return RedirectToAction("ShowSchedules");
            }
            return View("AddForm", schedule);
        }
        public IActionResult EditForm(int id)
        {            
            return View(scheduleRepository.GetScheduleById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Schedule schedule)
        {
            if(ModelState.IsValid)
            {
                scheduleRepository.EditSchedule(id,schedule);
                return RedirectToAction("ShowSchedules");
            }
            return View("EditForm", schedule);
        }
        public IActionResult Delete(int id)
        {
            scheduleRepository.DeleteScheduleById(id);
            return RedirectToAction("ShowSchedules");
        }

        DateOnly GetStartDateOfCurrentWeek()
        {
            DateTime Now = DateTime.Now;
            int Diff = ((Now.DayOfWeek - DayOfWeek.Saturday) + 7) % 7;
            DateTime StartOfWeek = Now.AddDays(-1 * Diff);
            return new DateOnly(StartOfWeek.Year, StartOfWeek.Month, StartOfWeek.Day);
        }
    }
}
