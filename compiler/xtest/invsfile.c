//
// Created by Amin Badin [@AminCoder] on 7/16/2020.
// Cv : www.AminCoder.ir
// Mail : dev@yo-lang.org
// Repository : https://github.com/YODevs/YO
// Official Website : www.yo-lang.org
//

//invoke source file
#include "invsfile.h"
#include "../lexer/impfile.h"
#include "../err/clierr.h"
#include <stdio.h>
#include <malloc.h>
#include <stdbool.h>

#define MAXCHAR 2

//Invoke ex : yoc.exe build ...
extern void invoke_build_command(char fileaddress[])
{
    
    if (exist_file(fileaddress) == false)
    {
        cli_source_notfound_error(fileaddress);
        return;
    }
    
}

