//
// Created by AminCoder on 7/15/2020.
//

#include <stdio.h>
#include <string.h>
#include "cli.h"


//constant CLI text output.
const char  txt_main_cli[] = "Welcome to YOLang.\n"
                             "This text will be updated soon."
                            ;
//

void init_main_cli()
{
    printf("%s",txt_main_cli);
}
