config = 
{
  :course_name => "Shaw - August 2011",
  :project => "nothinbutdotnetstore",
  :target => "Debug",
  :source_dir => "source",
  :app_dir => delayed{File.join(configatron.source_dir,"nothinbutdotnetstore.web.ui")},
  :all_references => UniqueFiles.new(Dir.glob("packages/**/*.{dll,exe}")).all_files,
  :artifacts_dir => "artifacts",
  :config_dir => "source/config",
  :log_file_name => delayed{"#{configatron.project}_log.txt"},
  :log_level => "DEBUG"
}
configatron.configure_from_hash config
