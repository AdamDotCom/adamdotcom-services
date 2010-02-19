﻿using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using AdamDotCom.Common.Service.Infrastructure.JSONP;

[assembly: ContractNamespace("http://adam.kahtava.com/services/amazon", ClrNamespace = "AdamDotCom.Amazon.Service")]
namespace AdamDotCom.Amazon.Service
{
    [ServiceContract(Namespace = "http://adam.kahtava.com/services/amazon")]
    public interface IAmazon
    {
        [OperationContract]
        [WebGet(UriTemplate = "reviews/id/{customerId}/xml")]
        Reviews ReviewsByCustomerIdXml(string customerId);

        [OperationContract]
        [JSONPBehavior(callback = "jsonp")]
        [WebGet(UriTemplate = "reviews/id/{customerId}/json", ResponseFormat = WebMessageFormat.Json)]
        Reviews ReviewsByCustomerIdJson(string customerId);

        [OperationContract]
        [WebGet(UriTemplate = "reviews/user/{username}/xml")]
        Reviews ReviewsByUsernameXml(string username);

        [OperationContract]
        [JSONPBehavior(callback = "jsonp")]
        [WebGet(UriTemplate = "reviews/user/{username}/json", ResponseFormat = WebMessageFormat.Json)]
        Reviews ReviewsByUsernameJson(string username);

        [OperationContract]
        [WebGet(UriTemplate = "wishlist/id/{listId}/xml")]
        Wishlist WishlistByListIdXml(string listId);

        [OperationContract]
        [JSONPBehavior(callback = "jsonp")]
        [WebGet(UriTemplate = "wishlist/id/{listId}/json", ResponseFormat = WebMessageFormat.Json)]
        Wishlist WishlistByListIdJson(string listId);

        [OperationContract]
        [WebGet(UriTemplate = "wishlist/user/{username}/xml")]
        Wishlist WishlistByUsernameXml(string username);

        [OperationContract]
        [JSONPBehavior(callback = "jsonp")]
        [WebGet(UriTemplate = "wishlist/user/{username}/json", ResponseFormat = WebMessageFormat.Json)]
        Wishlist WishlistByUsernameJson(string username);

        [OperationContract]
        [WebGet(UriTemplate = "discover/user/{username}/xml")]
        Profile DiscoverUsernameXml(string username);

        [OperationContract]
        [JSONPBehavior(callback = "jsonp")]
        [WebGet(UriTemplate = "discover/user/{username}/json", ResponseFormat = WebMessageFormat.Json)]
        Profile DiscoverUsernameJson(string username);
    }
}