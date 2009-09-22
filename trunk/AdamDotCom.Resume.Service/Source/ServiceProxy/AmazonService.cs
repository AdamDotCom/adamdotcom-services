﻿using System.Runtime.Serialization;
using System.ServiceModel;

[assembly: ContractNamespace("http://adam.kahtava.com/services/amazon", ClrNamespace = "AdamDotCom.Resume.Service.Proxy")]
namespace AdamDotCom.Resume.Service.Proxy
{
    public class AmazonService : ClientBase<IAmazon>, IAmazon
    {
        public AmazonResponse Reviews(string customerId)
        {
            return base.Channel.Reviews(customerId);
        }

        public AmazonResponse Wishlist(string listId)
        {
            return base.Channel.Wishlist(listId);
        }
    }
}