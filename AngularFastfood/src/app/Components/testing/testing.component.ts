import { Component, OnInit } from '@angular/core';
import { Login, ClassLogin } from '../../Models/Login';
import { Order } from '../../Models/Order';
import { LoginService } from '../../Services/login.service';
import { OrderService } from '../../Services/order.service';

@Component({
  selector: 'app-testing',
  templateUrl: './testing.component.html',
  styleUrls: ['./testing.component.css']
})
export class TestingComponent implements OnInit {
  _Login: Login;
  _Order: Order;

  constructor(
    private loginService: LoginService,
    private orderService: OrderService

  ) { }

  ngOnInit(): void {
    this.ToLogin();
  }

  private ToLogin(){
    this.loginService.ToLogin("jegerenewmwail@treuessss.dk", "/JEgeretsikkertpassword123")
      .subscribe(login => 
        this._Login = login)
  }

  public GetOrder(){
    this.orderService.GetOrder()
      .subscribe(order => 
        this._Order = order)
  }
}
