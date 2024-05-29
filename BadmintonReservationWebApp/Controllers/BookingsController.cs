using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonReservationData;
using BadmintonReservationBusiness;

namespace BadmintonReservationWebApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly string API_BASE_URL = "https://localhost:7257/api/Booking/";
        private readonly NET1711_231_1_BadmintonReservationContext _unitOfWork = new NET1711_231_1_BadmintonReservationContext();
        public BookingsController()
        {
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            //var bizResult = await _bookingBusiness.GetAllAsync();
            //switch (bizResult.Status)
            //{
            //    case 400:
            //        return BadRequest();
            //        break;
            //    case 404:
            //        return NotFound();
            //        break;
            //    case 200:
            //        return View(bizResult.Data);
            //        break;
            //    case 201:
            //        return View(bizResult.Data);
            //    default:
            //        return StatusCode(500, "An internal server error occurred. Please try again later.");
            //        break;
            //}

            return NotFound();
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _unitOfWork.Bookings
                .Include(b => b.BookingType)
                .Include(b => b.Customer)
                .Include(b => b.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["BookingTypeId"] = new SelectList(_unitOfWork.BookingTypes, "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_unitOfWork.Customers, "Id", "FullName");
            ViewData["PaymentId"] = new SelectList(_unitOfWork.Payments, "Id", "Id");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,BookingTypeId,BookingDateFrom,BookingDateTo,Status,PromotionAmount,PaymentType,PaymentId,CreatedDate,UpdatedDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Add(booking);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingTypeId"] = new SelectList(_unitOfWork.BookingTypes, "Id", "Name", booking.BookingTypeId);
            ViewData["CustomerId"] = new SelectList(_unitOfWork.Customers, "Id", "FullName", booking.CustomerId);
            ViewData["PaymentId"] = new SelectList(_unitOfWork.Payments, "Id", "Id", booking.PaymentId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _unitOfWork.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["BookingTypeId"] = new SelectList(_unitOfWork.BookingTypes, "Id", "Name", booking.BookingTypeId);
            ViewData["CustomerId"] = new SelectList(_unitOfWork.Customers, "Id", "FullName", booking.CustomerId);
            ViewData["PaymentId"] = new SelectList(_unitOfWork.Payments, "Id", "Id", booking.PaymentId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,BookingTypeId,BookingDateFrom,BookingDateTo,Status,PromotionAmount,PaymentType,PaymentId,CreatedDate,UpdatedDate")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Update(booking);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingTypeId"] = new SelectList(_unitOfWork.BookingTypes, "Id", "Name", booking.BookingTypeId);
            ViewData["CustomerId"] = new SelectList(_unitOfWork.Customers, "Id", "FullName", booking.CustomerId);
            ViewData["PaymentId"] = new SelectList(_unitOfWork.Payments, "Id", "Id", booking.PaymentId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _unitOfWork.Bookings
                .Include(b => b.BookingType)
                .Include(b => b.Customer)
                .Include(b => b.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Bookings == null)
            {
                return Problem("Entity set 'NET1711_231_1_BadmintonReservationContext.Bookings'  is null.");
            }
            var booking = await _unitOfWork.Bookings.FindAsync(id);
            if (booking != null)
            {
                _unitOfWork.Bookings.Remove(booking);
            }
            
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_unitOfWork.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
