using DAL.Interface;

namespace BAL.Manager
{
	public class BaseManager
	{
		protected IUnitOfWork uOW;

		public BaseManager(IUnitOfWork uOW)
		{
			this.uOW = uOW;
		}
	}
}