using System;
using System.Linq;
using DapperExtensions;
using Insurance.Model.App.Enum;
using Insurance.Model.Interfaces;
using Insurance.Model.Poco;

namespace Insurance.Services.DataSourse
{
    public class ContactService : BaseService, IContactService
    {
        public Contact Login(string phone) {
            try {
                phone = new string(phone.Where(c => !char.IsWhiteSpace(c) && char.IsDigit(c)).ToArray());
                return Connection.GetList<Contact>(Predicates.Field<Contact>(x => x.Phone, Operator.Eq, phone)).FirstOrDefault();
            }
            catch {
                return null;
            }
        }

        public Contact GetByPublicKey(string pk) {
            try {
                Guid publicKey;
                return Guid.TryParse(pk, out publicKey) ? 
                    Connection.GetList<Contact>(Predicates.Field<Contact>(x => x.PublicKey, Operator.Eq, publicKey)).SingleOrDefault() : 
                    null;
            }
            catch {
                return null;
            }
        }

        public bool IsInRole(string pk, AppRole role) {
            try {
                return Connection.GetList<Contact>(Predicates.Field<Contact>(x => x.PublicKey.ToString(), Operator.Eq, pk)).Any();
            }
            catch {
                return false;
            }
        }
    }
}