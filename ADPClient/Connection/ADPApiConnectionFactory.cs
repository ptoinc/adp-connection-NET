/*# This file is part of adp-api-library.
# https://github.com/adp/adp-api-lib-net

# Copyright © 2015-2016 ADP, LLC.

# Licensed under the Apache License, Version 2.0 (the “License”);
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at

# http://www.apache.org/licenses/LICENSE-2.0

# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an “AS IS” BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
# express or implied.  See the License for the specific language
# governing permissions and limitations under the License.
*/
using System;
using ADPClient.Product;


namespace ADPClient
{
    public class ADPApiConnectionFactory
    {

        /// <summary>
        /// 
        /// </summary>
        public ADPApiConnectionFactory()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionCfg"></param>
        /// <returns></returns>
        public static ADPApiConnection createConnection(ConnectionConfiguration connectionCfg)
        {

            if (connectionCfg is AuthorizationCodeConfiguration)
            {
                return new AuthorizationCodeConnection(connectionCfg);
            }
            else if (connectionCfg is ClientCredentialConfiguration)
            {
                return new ClientCredentialConnection(connectionCfg);
            }
            else {
                throw new Exception("Grant type / Configuration type not implemented.");
            }
        }
    }
}

