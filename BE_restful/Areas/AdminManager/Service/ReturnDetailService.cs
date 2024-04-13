using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface ReturnDetailService
{
    public bool ReturnToAdmin(ReturnDetail detail);
    public bool UpdateReturnForAdmin(int returnId);
}
