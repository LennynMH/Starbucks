import { HttpHeaders } from "@angular/common/http";

export abstract class ServiceBase {

  GetHeader() {
    //debugger;
    const data = JSON.parse(localStorage.getItem("SessionToken"));
    let auth_token = data;
    let httpOptions =
    {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${auth_token}`
      })
    };
    return httpOptions;
  }

}