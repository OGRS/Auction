using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using Auction.BLL.Interfaces;
using Auction.PL.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Auction.PL.Controllers
{
    public class LotController : ApiController
    {
        private readonly ILotService lotService;

        public LotController(ILotService serv)
            => lotService = serv;

        [HttpGet]
        [ResponseType(typeof(LotModel))]
        public IHttpActionResult GetLots()
        {
            IEnumerable<LotDTO> lotDTOs = lotService.GetLots();
            if (lotDTOs == null)
                return NotFound();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, LotModel>()).CreateMapper();
            var lots = mapper.Map<IEnumerable<LotDTO>, List<LotModel>>(lotDTOs);

            return Ok(lots);
        }

        //[HttpGet]
        //[ResponseType(typeof(LotModel))]
        //public IHttpActionResult GetLotsByCategory(int id)
        //{
        //    IEnumerable<LotDTO> lotDTOs = lotService.GetLotsByCategory(id);
        //    if (lotDTOs == null)
        //        return NotFound();

        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, LotModel>()).CreateMapper();
        //    var lots = mapper.Map<IEnumerable<LotDTO>, List<LotModel>>(lotDTOs);

        //    return Ok(lots);
        //}

        [HttpGet]
        [ResponseType(typeof(LotModel))]
        public IHttpActionResult GetLotById(int id)
        {
            if (id == 0)
                return BadRequest();

            LotDTO lotDTO = lotService.GetLotById(id);
            if (lotDTO == null)
                return NotFound();

            return Ok(lotDTO);
        }
    }
}
