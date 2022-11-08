import { Component, OnInit } from '@angular/core';
import { TreeNode } from 'primeng/api';
@Component({
    selector: 'app-admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

    public gfg = true;
    public isquality = false;
    isMaintanence=false;
    IsSecurity=false;
    isHrDepartment=false;
    isProduction=false;
    constructor() { }

    ngOnInit(): void {

    }
    QualityExpandOrCollapse() {
        if (this.isquality) {
            this.isquality = false;

        }
        else

            this.isquality = true;
    }
    MaintanenceExpandOrCollapse()
    {
        if (this.isMaintanence) {
            this.isMaintanence = false;

        }
        else

            this.isMaintanence = true;

    }
    SecurityExpandOrCollapse()
    {
        if (this.IsSecurity) {
            this.IsSecurity = false;

        }
        else

            this.IsSecurity = true;

    }
    HrDepartmentExpandOrCollapse()
    {
        if (this.isHrDepartment) {
            this.isHrDepartment = false;

        }
        else

            this.isHrDepartment = true;

    }
    ProductionExpendOrCollapse()
    {
        if (this.isProduction) {
            this.isProduction = false;

        }
        else

            this.isProduction = true;

    }

}
