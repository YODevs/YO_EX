//
// Created by Amin Badin [@AminCoder] on 7/20/2020.
// Cv : www.AminCoder.ir
// Mail : dev@yo-lang.org
// Repository : https://github.com/YODevs/YO
// Official Website : www.yo-lang.org
//

#include <stdio.h>
#include <string.h>
#include "cli.h"

//constant CLI text output.
const char  txt_main_cli[] = "Welcome to YOLang.\n"
                             "This text will be updated soon.";
//

void init_main_cli()
{
    printf("%s",txt_main_cli);
}
