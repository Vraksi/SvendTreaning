import { Component, OnInit } from '@angular/core';
import { ClassLogin, Login } from 'src/app/Models/Login';
import { LoginService } from 'src/app/Services/login.service';
import { CookieHelperService } from 'src/app/Services/cookie-helper.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  //TODO: the screen size will adjust down to the smallest size it can accomodate but i can for the life of me 
  // just not get it show the content after dropdown the menu and collapse its just gone Example works so im missing something
  // But it works for now so im just going with it

  //Login element of this part should probably be a popup of some kind so that.

  _login = new ClassLogin();
  isLoggedIn: boolean;

  constructor(
    private loginService: LoginService,
    private cookieHelper: CookieHelperService
  ) { }

  ngOnInit(): void {
    
    this.isLoggedIn = false;
    this.isLoggedIn = this.cookieHelper.CheckIfLoggedIn();
    console.log("I STARTED " + this.isLoggedIn);
  }
  
  //TODO request to server
  LogOut(){
    console.log("you logged out");
    this.cookieHelper.DeleteCookieDoom;
  }
  
  //TODO needs a check whether or not token is still valid when opening website (request to server)


  ToLogin(_login: ClassLogin){
    this.loginService.ToLogin(_login.email, _login.password)
      .subscribe(login => 
        this._login = login)

    this.isLoggedIn = this.cookieHelper.CheckIfLoggedIn();
  }

}
