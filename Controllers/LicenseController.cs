using LisenceManagement.Dto;
using LicenseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly NarposmainlicensedbContext _dataContext;
        public LicenseController(NarposmainlicensedbContext context) {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bilgisayar>>> GetLicenses()
        {
            var query = from pc in _dataContext.Bilgisayars
                        join customer in _dataContext.Musteris on pc.MusteriId equals customer.Id
                        select new ComputerWithCustomer
                        {
                            Id = pc.Id,
                            customer_name = customer.MusteriAdi,
                            machine_name = pc.MakinaPcadi,
                            machine_no = pc.MakinaNo,
                            machine_key = pc.Pckey,
                            request_date = pc.LisansTarihi,
                            isValid = pc.Kullanabilir
                        };
            var result = await query.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ComputerWithCustomer>>> GetLicense(int id)
        {
            List<ComputerWithCustomer> list = new List<ComputerWithCustomer>();
            var pc = _dataContext.Bilgisayars.FirstOrDefault(c => c.Id == id);
            ComputerWithCustomer dto = new ComputerWithCustomer()
            {
                Id= pc.Id,
                customer_name= _dataContext.Musteris.FirstOrDefault(c=>c.Id==pc.Id).MusteriAdi,
                machine_name=pc.MakinaPcadi,
                machine_no = pc.MakinaNo,
                machine_key = pc.Pckey,
                request_date = pc.LisansTarihi,
                isValid = pc.Kullanabilir
            };
            list.Add(dto);
            return Ok(list);

        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<Musteri>>> GetCustomers()
        {
            return Ok(await _dataContext.Musteris.Select(m=>new {m.Id, m.MusteriAdi, m.KayitTarihi, m.MusteriAdres, m.YetkiliTelefon}).ToListAsync());
        }

        [HttpPost]
       public async Task<ActionResult<List<ComputerWithCustomer>>> createLicense(ComputerWithCustomer license)
       {
            Bilgisayar bilgisayar = new Bilgisayar();
            Random rnd = new Random();
            bilgisayar.Id = rnd.Next(1,1000000);
            bilgisayar.MakinaPcadi = license.machine_name;
            bilgisayar.Pckey = license.machine_key;
            bilgisayar.LisansTarihi = license.request_date;
            bilgisayar.Kullanabilir = true;
            bilgisayar.MakinaNo= license.machine_no;
            bilgisayar.MusteriId=_dataContext.Musteris.FirstOrDefault(c=>c.MusteriAdi== license.customer_name).Id;
            bilgisayar.LisansBitisTarihi= DateTime.Today.AddYears(1);
            bilgisayar.GuncellemeAlabilir = true;
            bilgisayar.DemoLisansBitisTarihi = DateTime.Today.AddYears(1);
            bilgisayar.TerminalSayisi = 0;
            _dataContext.Bilgisayars.Add(bilgisayar);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction("GetLisence", license);
        }

        [HttpPut]
        public async Task<ActionResult<List<Bilgisayar>>> updateLicense(ComputerWithCustomer license)
        {
            var bilgisayar=await _dataContext.Bilgisayars.FindAsync(license.Id);
            if (bilgisayar == null)
            {
                return BadRequest("Lisence not found");
            }
            bilgisayar.MusteriId = _dataContext.Musteris.FirstOrDefault(c => c.MusteriAdi == license.customer_name).Id;
            bilgisayar.MakinaPcadi = license.machine_name;
            bilgisayar.Pckey = license.machine_key;
            bilgisayar.Kullanabilir = true;

            await _dataContext.SaveChangesAsync();
            return Ok(bilgisayar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LisansIstek>>> deleteLicense(int id)
        {
            var dbLisence = await _dataContext.LisansIsteks.FindAsync(id);
            if (dbLisence == null)
            {
                return BadRequest("Lisence not found");
            }
            _dataContext.LisansIsteks.Remove(dbLisence);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Bilgisayars.ToListAsync());
        }
    }
}
