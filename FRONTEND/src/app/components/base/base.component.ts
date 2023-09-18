import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

export abstract class ComponentBase {
  public router: Router;
  public toastr: ToastrService;

  constructor(router: Router, toastr: ToastrService) {
    this.router = router;
    this.toastr = toastr;
  }

  ManageErrors(error: any) {
    try {
      if (error.status == 401) {
        localStorage.removeItem("isLogin");
        localStorage.removeItem("SessionToken");
        this.router.navigate(['/Login']);
      }
      else if (error.status == 400) {
        let message = error.error?.errors.detail.join("\r\n");;
        this.toastr.error("Error: " + message);
      }
    }
    catch (error) {
      this.toastr.error("Error: " + error);
    }
  }
}