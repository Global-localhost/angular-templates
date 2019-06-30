// npm Packages
import { Component, OnInit, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";$npmImports$

// API Services$apiImports$

// Other Service $serviceImports$

// Models$modelImports$

@Component({
    selector: "$selector$",
    templateUrl: "./$htmlFileName$",
    styleUrls: ["./$cssFileName$"]
})
export class $className$ implements OnInit {
    $dataOutputModelVariableDeclaration$
    constructor(
        private dialogRef: MatDialogRef<$className$>,
        @Inject(MAT_DIALOG_DATA) private inputData: $dataInputModel$
    ) {
    }

    ngOnInit() {
    }

    /**
     * Handles the OK button click event.
     */
    onOk() {
        this.dialogRef.close($dataOutputModelVariable$);
    }

    /**
     * Handles events to cancel (and close) the dialog.
     */
    onCancel() {
        this.dialogRef.close();
    }

}
