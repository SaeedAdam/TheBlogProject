let index = 0;

function addTag() {
    var tagEntry = document.getElementById("TagEntry");

    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
         //Trigger sweet alert for whatever condition is contained in the searchResult variable
         Swal.fire({
             icon: "error",
             title: "Oops...",
             text: `${searchResult.toUpperCase()}`,
             timer: 5000
         });


    } else {
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }

    // Clear out the tagEntry control
    tagEntry.value = "";

    return true;
}

function deleteTag() {
    let tagCount = 1;
    let tagList = document.getElementById("TagList");

    if (!tagList) {
        return false;
    }

    if (tagList.selectedIndex === -1) {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            html: "<span class = 'font-weight-bolder'>CHOOSE A TAG BEFORE DELETING</>",
            timer: 5000
        });
        return true;
    }


    while (tagCount > 0) {
        
        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            tagList.options[selectedIndex] = null;
            --tagCount;
        } else {
            tagCount = 0;
        }
        index--;
    }
    return false;
}

$("form").on("submit",
    function() {
        $("#TagList option").prop("selected", "selected");
    });

//Look for the tagValues variable to see if it has data
if (tagValues !== "") {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        // Load or replace current options
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

//The Search function wil detect either an empty or a duplicate Tag in a post 
//and return an error string if an error is detected
function search(str) {
    if (str === "") {
        return "Empty tags are not permitted";
    }

    const tagsEl = document.getElementById("TagList");

    if (tagsEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value === str)
                return `The tag #${str} was detected as a duplicate and not permitted`;
        }
    }
    return "Empty tags are not permitted";
}