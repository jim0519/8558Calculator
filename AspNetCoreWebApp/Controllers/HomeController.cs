using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApp.Models;
using AspNetCoreWebApp.DbModels.CalculatorDbModels;
using AspNetCoreWebApp.Filters;
using AspNetCoreWebApp.Business;
using RestSharp;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreWebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly CalculatorContext _dbContext;
        private readonly SignInManager<AspNetUsers> _signInManager;
        private readonly UserManager<AspNetUsers> _userManager;

        public HomeController(CalculatorContext dbContext,
            UserManager<AspNetUsers> userManager,
            SignInManager<AspNetUsers> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [CustomerFilter(true)]
        public async Task<IActionResult> Index(bool isContinue)
        {
            //_dbContext.Database.EnsureCreated();
            var users = _dbContext.Users;
            foreach (var user in users)
            {

            }

            //var newUser= new AspNetUsers { UserName = "jim0519", Email = "gdutjim@gmail.com" };
            //var result = await _userManager.CreateAsync(newUser, "Shishiliu-0310");
            //if (result.Succeeded)
            //{
            //    //await _signInManager.SignInAsync(newUser, isPersistent: true);
            //}
                //var newUser = new User();
                //newUser.EmailAddress = "gdutjim@gmail.com";
                //newUser.Password = "123";
                //newUser.FirstName = "Jing";
                //newUser.LastName = "Xu";
                //newUser.Status = 1;
                //newUser.CreateBy = newUser.EmailAddress;
                //newUser.CreateTime = DateTime.Now;
                //newUser.EditBy = newUser.EmailAddress;
                //newUser.EditTime = DateTime.Now;

                //users.Add(newUser);
                //_dbContext.SaveChanges();



                //using (var dbcontext = new AutoPostAdDealSplashContext())
                //{
                //    dbcontext.Database.EnsureCreated();
                //}

                return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            //return Ok();
            return View();
        }

        public IActionResult Disclaimer()
        {
            ViewData["Message"] = "Disclaimer";

            //return Ok();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [CustomAuthorization]
        public IActionResult Calculator()
        {
            var model = new CalculatorViewModel();
            //model.VisaStartDate =Convert.ToDateTime( "01-01-2017");
            //model.VisaEndDate = Convert.ToDateTime("01-01-2020");
            int startYear = DateTime.Now.AddYears(-1).Year;
            int endYear= DateTime.Now.AddYears(2).Year;
            DateTime firstDay = new DateTime(startYear, 1, 1);
            DateTime lastDay = new DateTime(endYear, 1, 1);
            model.VisaStartDate = firstDay;
            model.VisaEndDate = lastDay;
            return View(model);
        }

        [HttpPost]
        public IActionResult Calculator(CalculatorViewModel model)
        {
            if (model != null)
            {

                var calService = new CalculatorService();
                var record = (IList<EntryDepart>)model.EntryDepartRecord;
                var resultMonths = calService.CalculateResult(ref record, model.VisaStartDate.Value, model.VisaEndDate.Value);
                var formattedEntryDepartRecord = new List<dynamic>();
                if (record != null)
                    record.ToList().ForEach(edr =>
                {
                    formattedEntryDepartRecord.Add(new { EntryDate = edr.EntryDate.ToString("dd/MM/yyyy"), DepartDate = edr.DepartDate.Value.ToString("dd/MM/yyyy") });
                });
                return Json(new { Result = true, Data = new { ResultMonths = resultMonths, EntryDepartRecord = formattedEntryDepartRecord } });
            }
            else
                return Json(new { Result = false });
        }

        public IActionResult VotoboSearch()
        {
            ViewData["Message"] = "Votobo Search";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VotoboSearch(string timeStamp,string authToken,string keyword)
        {

            var client = new RestClient("http://member.votobo.com/");
            var votoboFeedRequest = new RestRequest("api/index.php?mod=vstatistics.getList&page=1&rowsPerPage=100&listType={listType}&productOrderby=&platform=ebay&storeNameLike=&itemId=&priceMin={priceMin}&priceMax={priceMax}&days7totalSoldMin={days7totalSoldMin}&days7totalSoldMax={days7totalSoldMax}&country=&timeStart=&totalSoldMin={totalSoldMin}&totalSoldMax={totalSoldMax}&firseCategoryId=&secondCategoryId=&categoryId=&siteId={siteID}&isUseDefault=1&nameLike={keyword}&sellerType=&offerCntGt=&offerCntLt=&bsrCategoryLike=&rankGt=&rankLt=&scoreMin=&scoreMax=&commentCntMin=&commentCntMax=&before7CommentMin=&before7CommentMax=&mKey=fbbf15cc4e6f9433508f9873182d35b0&categoryIdName=&time={timeStamp}&authToken={authToken}");
            //listType: isHot, isSearch
            //priceMin
            //priceMax
            //days7totalSoldMin
            //days7totalSoldMax
            //totalSoldMin
            //totalSoldMax
            //siteID
            //timeStamp
            //authToken
            //keyword
            votoboFeedRequest.AddUrlSegment("priceMin", "5");
            votoboFeedRequest.AddUrlSegment("priceMax", "50");
            votoboFeedRequest.AddUrlSegment("days7totalSoldMin", "2");
            votoboFeedRequest.AddUrlSegment("days7totalSoldMax", "");   
            votoboFeedRequest.AddUrlSegment("totalSoldMin", "");
            votoboFeedRequest.AddUrlSegment("totalSoldMax", "");
            votoboFeedRequest.AddUrlSegment("siteID", 15);
            votoboFeedRequest.AddUrlSegment("listType", "isSearch");
            //votoboFeedRequest.AddUrlSegment("timeStamp", timeStamp);
            //votoboFeedRequest.AddUrlSegment("authToken", authToken);
            votoboFeedRequest.AddParameter("timeStamp", timeStamp, ParameterType.UrlSegment);
            votoboFeedRequest.AddParameter("authToken", authToken, ParameterType.UrlSegment);
            votoboFeedRequest.AddUrlSegment("keyword", keyword);
            var cookie = "rememberUserTime=1553742276; noticeVersion=v2.4; gr_user_id=cb103169-302a-4711-b501-78d4d6d80c68; PHPSESSID=u170vgg0igp8ukomot4mfmuc22; gr_session_id_b4063391519ebb65=385acb81-3b4e-48b5-8c4e-ca8df3e7e80c; gr_cs1_385acb81-3b4e-48b5-8c4e-ca8df3e7e80c=uid%3A; gr_session_id_b4063391519ebb65_385acb81-3b4e-48b5-8c4e-ca8df3e7e80c=true; privateMabang=0; token=6b00600a81ae6843823f678bf93c1243; memberKey=FFC%2FIdfOOzr2V1kTcKM; memberType=1; privateUrl=member.votobo.com".Replace(";", ",");
            //var cookieContainerString = ad.Cookie.Replace(";", ",");
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.SetCookies(new Uri("http://member.votobo.com"), cookie);
            client.CookieContainer = cookieContainer;
            VotoboResult votoboResult = null;
            IRestResponse<VotoboResult> resultResponse=null;
            //var taskCompletionSource = new TaskCompletionSource<VotoboResult>();

            //var requestHandler = client.ExecuteAsync<VotoboResult>(votoboFeedRequest,response=> {
            //    if (response.Data != null)
            //    {
            //        votoboResult= response.Data;
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    resultResponse = await GetResponseContentAsync(client, votoboFeedRequest) as IRestResponse<VotoboResult>;
            //}).Wait();
            resultResponse = await GetResponseContentAsync(client, votoboFeedRequest) as IRestResponse<VotoboResult>;
            votoboResult = resultResponse.Data;
            //taskCompletionSource.Task.Wait();
            //votoboResult = taskCompletionSource.Task.Result;
            return Ok(Json(new { Result = true, Data = votoboResult }));
            //return await Task.FromResult( Json(new { Result = true, Data = votoboResult }));
        }

        public Task<IRestResponse<VotoboResult>> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse<VotoboResult>>();
            theClient.ExecuteAsync<VotoboResult>(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
