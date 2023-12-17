<script>

        const developerModeSwitch = document.getElementById('developerModeSwitch');

        developerModeSwitch.addEventListener('change', function () {
            debugger;
            if (developerModeSwitch.checked) {
                // Developer mode is ON
                alert('Developer Mode is ON');
                // Add your developer-related actions here
            } else {
                // Developer mode is OFF
                alert('Developer Mode is OFF');
                // Remove or disable developer-related actions here
            }
        });
      
	   
     function showUserProfile() {
         var userInfo = document.getElementById('userInfo');
         userInfo.style.display = userInfo.style.display === 'none' ? 'block' : 'none';
     }



     function showUserProfile() {
         var modalBackground = document.getElementById('modalBackground');
         modalBackground.style.display = 'flex';
     }

     function hideUserProfile() {
         var modalBackground = document.getElementById('modalBackground');
         modalBackground.style.display = 'none';
     }

     function logout() {

    window.location.href = '/FrontEnd/Login.aspx';
}

 
</script>