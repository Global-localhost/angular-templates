// npm Packages
import { Component, OnInit, Inject } from $stringDelimiter$@angular/core$stringDelimiter$;
import { MAT_DIALOG_DATA, MatDialogRef } from $stringDelimiter$@angular/material$stringDelimiter$;$packageImports$

// API Services$apiImports$

// Other Services$serviceImports$

// Models$modelImports$

@Component({
    selector: $stringDelimiter$$selector$$stringDelimiter$,
    templateUrl: $stringDelimiter$./$htmlFileName$$stringDelimiter$,
    styleUrls: [$stringDelimiter$./$cssFileName$$stringDelimiter$]
})
export class $className$ implements OnInit {
    private outputData: $dataOutputModelType$;

    constructor(
        private dialogRef: MatDialogRef<$className$>,
        @Inject(MAT_DIALOG_DATA) private inputData: $dataInputModelType$$constructorInjects$
    ) {
    }

    ngOnInit() {
    }

    /**
     * Handles events to cancel (and close) the dialog.
     */
    onCancel() {
        this.dialogRef.close();
    }

    /**
     * Handles the OK button click event.
     */
    onOk() {
        this.dialogRef.close(this.outputData);
    }
}
