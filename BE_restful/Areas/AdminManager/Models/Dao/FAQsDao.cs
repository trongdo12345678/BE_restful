using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class FAQsDao : FAQsService
{
    private readonly ArtsContext _context;
    public FAQsDao(ArtsContext context)
    {
        _context = context;
    }
    public bool AddQuesionFAQ(Faq FQ)
    {
        try
        {
            _context.Faqs.Add(FQ);
            return _context.SaveChanges() > 0;
        }catch (Exception)
        {
            return false;
        }
    }
    public List<Faq> GetFAQ()
    {
        try
        {
            var fa = (from p in _context.Faqs
                         select new Faq
                         {
                             Faqid = p.Faqid,
                             Question = p.Question,
                             CustomerId = p.CustomerId,
                             Answer = p.Answer,
                             Customer = (from pi in _context.Customers
                                         where pi.Email == pi.Email
                                         select pi).FirstOrDefault()
                         }).ToList();

            return fa;
        }
        catch (Exception)
        {
            return [];
        }
    }

}
