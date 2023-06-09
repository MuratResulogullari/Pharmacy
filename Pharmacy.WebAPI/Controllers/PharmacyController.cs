﻿using Microsoft.AspNetCore.Mvc;
using Pharmacy.Business.Abstract;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Pharmacies;

namespace Pharmacy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpPost("CreatePharmacy")]
        public async Task<ActionResult<RequestResult>> CreatePharmacyAsync(PharmacyDTO dto)
        {
            RequestResult requestResult = new();

            var entity = new Pharmacy.Core.Entities.Pharmacies.Pharmacy
            {
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Status = dto.Status,
                LanguageId = dto.LanguageId,
                Enable = dto.Enable,
                SortOrder = dto.SortOrder
            };
            return await _pharmacyService.CreateAsync(entity);
        }

        [HttpPut("UpdatePharmacy")]
        public async Task<ActionResult<RequestResult>> UpdatePharmacyAsync(PharmacyDTO dto)
        {
            var entity = new Pharmacy.Core.Entities.Pharmacies.Pharmacy
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Status = dto.Status,
                LanguageId = dto.LanguageId,
                Enable = dto.Enable,
                SortOrder = dto.SortOrder
            };
            return await _pharmacyService.UpdateAsync(entity);
        }

        [HttpDelete("deletePharmacy/{id}")]
        public async Task<ActionResult<RequestResult>> DeletePharmacyAsync(int id)
        {
            var entity = new Core.Entities.Pharmacies.Pharmacy
            {
                Id = id
            };
            return await _pharmacyService.DeleteAsync(entity);
        }

        [HttpGet("getPharmacyById/{id}")]
        public async Task<ActionResult<RequestResult>> GetPharmacyById(int id)
        {
            return await _pharmacyService.GetByIdsAsync(new int[1] { id });
        }
        [HttpPost("getPharmacyPagedList")]
        public async Task<ActionResult<RequestResult<PagedResult>>> GetPharmacyPagedList(PagedCriteriaObject pagedCriteria)
        {
            return await _pharmacyService.PagedListAsync(x=>x.Enable && x.DeletedOn==null,pagedCriteria);
        }
    }
}