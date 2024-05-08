using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface FAQsService
{
    public List<Faq> GetFAQ();
    public bool AddQuesionFAQ(Faq FQ);
}
