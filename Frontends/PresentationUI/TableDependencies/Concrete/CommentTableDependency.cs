using PresentationUI.Hubs;
using PresentationUI.TableDependencies.Abstract;
using PresentationUI.TableDependencies.Entities;
using TableDependency.SqlClient;

namespace PresentationUI.TableDependencies.Concrete
{
    public class CommentTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<UserComment> _tableDependency;
        AppHub _appHub;

        public CommentTableDependency(AppHub appHub)
        {
            _appHub = appHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            _tableDependency = new SqlTableDependency<UserComment>(connectionString);
            _tableDependency.OnChanged += _tableDependency_OnChanged;
            _tableDependency.OnError += _tableDependency_OnError;
            _tableDependency.Start();
        }

        private void _tableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _tableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<UserComment> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                var productID = e.Entity.ProductID;
                _appHub.SendCommentCount(productID);
            }
        }
    }
}
