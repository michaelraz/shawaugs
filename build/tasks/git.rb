namespace :git do
  desc 'set up the remotes for git'
  task :student_remotes do
    puts configatron.git.repo
    configatron.git.remotes.each do|remote|
      `git remote rm #{remote}`
      `git remote add #{remote} http://github.com/#{remote}/#{configatron.git.repo}`
    end
  end

  desc "Configure the remote connection to JP"

  task :setup_remote_to_jp do
    `git remote rm jp`
    `git remote add jp git://github.com/developwithpassion/#{configatron.git.repo}.git`
  end
end
