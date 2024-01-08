
            window.onload = function() {
                console.log('Page has finished loading!');
            };
            
            function makeAjaxRequest() {
                var xhr = new XMLHttpRequest();
                xhr.open('GET', '/example/data', true);
                xhr.onload = function() {
                    if (xhr.status >= 200 && xhr.status < 300) {
                        console.log('Success! Response:', xhr.responseText);
                    } else {
                        console.error('Request failed. Status:', xhr.status, 'Response:', xhr.responseText);
                    }
                };
                xhr.onerror = function() {
                    console.error('Network error occurred');
                };
                xhr.send();
            }
            