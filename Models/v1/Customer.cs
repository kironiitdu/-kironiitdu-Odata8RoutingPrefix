// Copyright saxu@microsoft.com.  All rights reserved.
// Licensed under the MIT License.

namespace ODataApiVersion.Models.v1
{
    public class Customer : CustomerBase
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
    public class ProjectInfo
    {
        public int Id { get; set; }
        public string ApiVersion { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
