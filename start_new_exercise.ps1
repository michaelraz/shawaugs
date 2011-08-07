. .\psh_git_utils.ps1

exit_if_on_the_master_branch

$now = get-date
$new_branch_name = "$($now.year)$($now.month.tostring("00"))$($now.day.tostring("00"))$($now.hour.tostring("00"))$($now.minute.tostring("00"))$($now.second.tostring("00"))"
git add -A
git commit -m "Committing"
git checkout master

exit_if_not_on_the_master_branch

checkout($new_branch_name)
git pull jp master
echo "new branch name:$new_branch_name"

