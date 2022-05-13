using cadastro_ubuntu.repository;
using Cadastro_Ubuntu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using QRCoder;
//using System.Web.Mvc;
//using Cadastro_Ubuntu.Filters;

namespace CadastroUbuntu.Controllers
{
    //[PaginaParaUsuarioLogado]
    public class UbuntuController : Controller
    {
        private readonly IUbuntuRepository _ubuntuRepository;
        public UbuntuController(IUbuntuRepository ubuntuRepository)
        {
            _ubuntuRepository = ubuntuRepository;
        }
        public IActionResult Index()
        {
            List<Ubuntu> ubuntus = _ubuntuRepository.BuscarTodos();

            return View(ubuntus);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            Ubuntu ubuntu = _ubuntuRepository.ListarPorId(id);
            return View(ubuntu);
        }

        public IActionResult Delete(int id)
        {
            Ubuntu ubuntu = _ubuntuRepository.ListarPorId(id);
            return View(ubuntu);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _ubuntuRepository.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Ubuntu apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o Ubuntu, tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o Ubuntu, tente novamente, mais detalhes do erro:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(Ubuntu ubuntu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ubuntuRepository.Adicionar(ubuntu);
                    TempData["MensagemSucesso"] = "Ubuntu Salvo com sucesso";
                    return RedirectToAction("Index");
                }

                return View(ubuntu);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o Ubuntu, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(Ubuntu ubuntu)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _ubuntuRepository.Atualizar(ubuntu);
                    TempData["MensagemSucesso"] = "Ubuntu Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", ubuntu);


            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar o Ubuntu, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }



        }
        public IActionResult Details()
        {

            return View();
        }
        public IActionResult _Modal(int id)
        {

            Ubuntu ubuntu = _ubuntuRepository.ListarPorId(id);
            return PartialView(ubuntu);
        }


        [HttpPost]
        public IActionResult _Modal(string id)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytes(qrCodeImage));
        }
        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
            }
        }
}







//#nullable disable
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Cadastro_Ubuntu.Data;
//using Cadastro_Ubuntu.Models;

//namespace Cadastro_Ubuntu.Controllers
//{
//    public class UbuntuController : Controller
//    {
//        private readonly DefaultConnection _context;

//        public UbuntuController(DefaultConnection context)
//        {
//            _context = context;
//        }

//        // GET: Ubuntu
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Ubuntu.ToListAsync());
//        }

//        // GET: Ubuntu/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ubuntu = await _context.Ubuntu
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (ubuntu == null)
//            {
//                return NotFound();
//            }

//            return View(ubuntu);
//        }

//        // GET: Ubuntu/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Ubuntu/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Nome,Linguagem,Nivel")] Ubuntu ubuntu)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(ubuntu);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(ubuntu);
//        }

//        // GET: Ubuntu/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ubuntu = await _context.Ubuntu.FindAsync(id);
//            if (ubuntu == null)
//            {
//                return NotFound();
//            }
//            return View(ubuntu);
//        }

//        // POST: Ubuntu/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Linguagem,Nivel")] Ubuntu ubuntu)
//        {
//            if (id != ubuntu.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(ubuntu);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UbuntuExists(ubuntu.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(ubuntu);
//        }

//        // GET: Ubuntu/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ubuntu = await _context.Ubuntu
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (ubuntu == null)
//            {
//                return NotFound();
//            }

//            return View(ubuntu);
//        }

//        // POST: Ubuntu/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var ubuntu = await _context.Ubuntu.FindAsync(id);
//            _context.Ubuntu.Remove(ubuntu);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UbuntuExists(int id)
//        {
//            return _context.Ubuntu.Any(e => e.Id == id);
//        }
//    }
//}
