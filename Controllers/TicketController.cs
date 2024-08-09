using Cyrus_Technology_Task.DTOs;
using Cyrus_Technology_Task.Models;
using Cyrus_Technology_Task.Repositories;
using Cyrus_Technology_Task.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyrus_Technology_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly IAppUserRepository _AppUserRepository;
        private readonly ITicketRepository _TicketRepository;



        public TicketController(IAppUserRepository AppUserRepository, ITicketRepository TicketRepository)
        {
            _AppUserRepository = AppUserRepository;
            _TicketRepository = TicketRepository;


        }

        [HttpPost("Create")]
        public async Task<GeneralResponse> CreateTicket(TicketDTO ticketmodel)
        {

            if (ModelState.IsValid)
            {
                var response = await GetAllTickets();
                var ticketlist = response.Data as List<TicketDTO>;
                if (ticketlist.Any(t => t.UserPhoneNumber == ticketmodel.UserPhoneNumber))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "there is already ticket with this mobile number ",
                        Status = 404

                    };
                }


                AppUser appUser = _AppUserRepository.Get(ticketmodel.UserPhoneNumber);
                if (appUser == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "there is no such phonenumber",
                        Status = 404

                    };
                }
                else
                {
                    Ticket ticket = new Ticket
                    {
                        TicketImage = ticketmodel.TicketImage,
                        TicketNumber = ticketmodel.TicketNumber,
                        UserPhoneNumber = ticketmodel.UserPhoneNumber,
                        UserId = appUser.Id

                    };
                    _TicketRepository.Insert(ticket);
                    _TicketRepository.Save();
                    return new GeneralResponse
                    {
                        Data = ticketmodel,
                        IsSuccess = true,
                        Message = "Ticket created successfully",
                        Status = 200
                    };
                }
            }
            else
            {
                return new GeneralResponse
                {
                    Data = ticketmodel,
                    IsSuccess = false,
                    Status = 400,
                    Message = "there is error in your model "
                };
            }

        }


        [HttpGet("GetAllTickets")]
        public async Task<GeneralResponse> GetAllTickets()
        {
            List<Ticket> tickets = _TicketRepository.GetAll();

            List<TicketDTO> ticketsDTOs = new List<TicketDTO>();

            foreach (Ticket ticket in tickets)
            {
                TicketDTO ticketDTO = new TicketDTO()
                {
                    TicketImage = ticket.TicketImage,
                    TicketNumber = ticket.TicketNumber,
                    UserPhoneNumber = ticket.UserPhoneNumber,

                };

                ticketsDTOs.Add(ticketDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = ticketsDTOs,
                Message = "All Tickets"
            };
        }

        [HttpGet("GetoneTicket")]
        public ActionResult<GeneralResponse> GetTicketDetails(string userphonenumber)
        {
            Ticket ticket = _TicketRepository.Get(userphonenumber);
            if(ticket==null)
            {
                return new GeneralResponse
                {
                    IsSuccess=false,
                    Data = null,
                    Message="there is not ticket with this phone number"
                };
            }
            else
            {
                TicketDTO ticketDTO = new TicketDTO
                {
                    TicketImage = ticket.TicketImage,
                    TicketNumber = ticket.TicketNumber,
                    UserPhoneNumber = ticket.UserPhoneNumber
                };
                return new GeneralResponse
                {
                    IsSuccess=true,
                    Data = ticketDTO,
                    Message="Ticket founded"
                };
            }
          


        }
    }
}
