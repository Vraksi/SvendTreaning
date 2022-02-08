import { Component, OnInit } from '@angular/core';
import { ClassLogin, Login } from 'src/app/Models/Login';
import { LoginService } from 'src/app/Services/login.service';
import { CookieHelperService } from 'src/app/Services/cookie-helper.service';
import { CookieService } from 'ngx-cookie-service';


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
  _isLoggedIn: boolean;

  constructor(
    private loginService: LoginService
  ) { }

  ngOnInit(): void {
    this._isLoggedIn = false;
    this.CheckLogin();
    //this.isLoggedIn = this.loginService.CheckIfLoggedOut();
    console.log("am i logged in " + this._isLoggedIn);
  }
  
  //Makes a request to the server to log out it does this by deleting the cookie from identity
  LogOut(){
    this.loginService.ToLogOut()
      .subscribe()  
  }
  
  
  //TODO needs a check whether or not token is still valid when opening website (request to server)
  CheckLogin(){
    this.loginService.CheckIfLoggedOut()
      .subscribe(res => {
        this._isLoggedIn = res;
        console.log("dwaw", this._isLoggedIn)
      })
  }

  ToLogin(_login: ClassLogin){
    this.loginService.ToLogin(_login.email, _login.password)
      .subscribe(login => { 
        this._login = login;
      })
  }

}
