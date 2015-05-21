using System;
using Xamarin.Forms;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;

namespace MVVMEasy
{
    class MVVMCommand : Command {
        public MVVMCommand (Action<Object> action, Expression<Func<Object, bool>> propExpression) : base(action, propExpression.Compile())
        {
            var member = propExpression.Body as MemberExpression;
            var expression = member.Expression  as ConstantExpression;

            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propExpression.ToString()));
            if (expression == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' should be a constant expression",
                    propExpression.ToString()));
            var host = (INotifyPropertyChanged)expression.Value;
            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propExpression.ToString()));
            var Prop = propInfo.Name;
            host.PropertyChanged += (sender, e) => {
                if (e.PropertyName == Prop) {
                    this.ChangeCanExecute();
                };
            };
        }
    }}
